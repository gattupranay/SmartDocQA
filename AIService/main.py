from fastapi import FastAPI, File, UploadFile
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel
import openai
import PyPDF2
import docx
import os
from io import BytesIO

app = FastAPI()

# Enable CORS
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Set your OpenAI API key here
openai.api_key = "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"  

class QuestionRequest(BaseModel):
    question: str
    context: str

@app.get("/")
def read_root():
    return {"message": "AI Service is running"}

@app.post("/extract")
async def extract_text(file: UploadFile = File(...)):
    """Extract text from uploaded document"""
    try:
        content = await file.read()
        text = ""
        
        if file.filename.endswith('.pdf'):
            # Extract from PDF
            pdf_file = BytesIO(content)
            pdf_reader = PyPDF2.PdfReader(pdf_file)
            for page in pdf_reader.pages:
                text += page.extract_text()
        
        elif file.filename.endswith('.docx'):
            # Extract from Word document
            doc = docx.Document(BytesIO(content))
            for para in doc.paragraphs:
                text += para.text + "\n"
        
        elif file.filename.endswith('.txt'):
            # Extract from text file
            text = content.decode('utf-8')
        
        else:
            return {"error": "Unsupported file format"}
        
        return text
    
    except Exception as e:
        return {"error": str(e)}

@app.post("/ask")
async def ask_question(request: QuestionRequest):
    """Answer questions based on document context using OpenAI"""
    try:
        from openai import OpenAI
        client = OpenAI(api_key=openai.api_key)
        
        # Create prompt for GPT
        prompt = f"""Based on the following document content, answer the question accurately and concisely.

Document Content:
{request.context[:3000]}

Question: {request.question}

Answer:"""

        # Call OpenAI API (new version)
        response = client.chat.completions.create(
            model="gpt-3.5-turbo",
            messages=[
                {"role": "system", "content": "You are a helpful assistant that answers questions based on provided document content."},
                {"role": "user", "content": prompt}
            ],
            max_tokens=500,
            temperature=0.7
        )
        
        answer = response.choices[0].message.content.strip()
        return answer
    
    except Exception as e:
        return {"error": str(e)}
    
if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="0.0.0.0", port=8000)