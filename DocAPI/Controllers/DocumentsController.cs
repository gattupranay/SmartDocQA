using Microsoft.AspNetCore.Mvc;
using DocAPI.Data;
using DocAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DocAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;

        public DocumentsController(AppDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        // Upload document
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            // Create uploads folder
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            Directory.CreateDirectory(uploadsFolder);

            // Save file
            var filePath = Path.Combine(uploadsFolder, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Send to Python AI service for text extraction
            var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(System.IO.File.OpenRead(filePath));
            content.Add(fileContent, "file", file.FileName);

            var response = await _httpClient.PostAsync("http://localhost:8000/extract", content);
            var extractedText = await response.Content.ReadAsStringAsync();

            // Save to database
            var document = new Document
            {
                FileName = file.FileName,
                FilePath = filePath,
                Content = extractedText,
                UploadedAt = DateTime.Now
            };

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return Ok(new { id = document.Id, message = "File uploaded successfully" });
        }

        // Get all documents
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var docs = await _context.Documents
                .Select(d => new
                {
                    d.Id,
                    d.FileName,
                    d.UploadedAt
                })
                .ToListAsync();

            return Ok(docs);
        }

        // Ask question about document
        [HttpPost("ask")]
        public async Task<IActionResult> AskQuestion([FromBody] QuestionRequest request)
        {
            var document = await _context.Documents.FindAsync(request.DocumentId);
            if (document == null)
                return NotFound("Document not found");

            // Send to Python AI service
            var jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(new
                {
                    question = request.Question,
                    context = document.Content
                }),
                System.Text.Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("http://localhost:8000/ask", jsonContent);
            var answer = await response.Content.ReadAsStringAsync();

            return Ok(new { answer });
        }
    }

    public class QuestionRequest
    {
        public int DocumentId { get; set; }
        public string Question { get; set; } = string.Empty;
    }
}