SmartDocQA 🤖
Ever found yourself digging through a long PDF trying to find one specific piece of information? Yeah, me too. That's why I built this.
SmartDocQA lets you upload any document and just ask questions about it. No more ctrl+F or endless scrolling - just ask in plain English and get answers powered by AI.
What does it do?
Pretty simple actually:

Upload a PDF, Word doc, or text file
Ask it questions like "What's this about?" or "What are the main points?"
Get instant answers from the AI

The app reads your document, understands the content, and answers based on what's actually in there.
How I built it
This was my first time combining three completely different tech stacks into one project. Here's what's under the hood:
The Backend (.NET Core)

Handles all the API requests and file uploads
Stores documents and their content in a SQLite database
Built with ASP.NET Core 8 and Entity Framework Core

The AI Part (Python)

Extracts text from PDFs and Word documents
Sends the content + your question to OpenAI's GPT-3.5
Returns the AI's answer back to you
Used FastAPI because it's fast and easy to work with

The Frontend (React)

Clean interface where you upload files and ask questions
Shows your uploaded documents and lets you select which one to query
Built with React because I wanted to learn it better

All three parts talk to each other through REST APIs. It's a microservices setup, which sounds fancy but really just means each piece does its own job independently.
Getting it running
What you'll need:

.NET SDK 8.0 or newer
Python 3.11 or newer
Node.js (for React)
An OpenAI API key 

Setup steps:

Clone this repo

bash   git clone https://github.com/gattupranay/SmartDocQA.git
   cd SmartDocQA

Start the .NET API

bash   cd DocAPI
   dotnet restore
   dotnet run
This runs on http://localhost:5161

Start the Python AI service

bash   cd AIService
   python -m venv venv
   source venv/bin/activate  # Mac/Linux
   # or venv\Scripts\activate on Windows
   
   pip install fastapi uvicorn openai python-multipart pypdf2 python-docx
   
   # IMPORTANT: Add your OpenAI API key in main.py
   python main.py
This runs on http://localhost:8000

Start the React frontend

bash   cd frontend
   npm install
   npm start
Opens at http://localhost:3000
Now you should have all three services running. Open your browser to localhost:3000 and you're good to go!
How to use it
It's pretty straightforward:

Click the file upload button and pick a document
Wait a sec while it processes (you'll see your doc appear in the list)
Click on the document to select it
Type your question in the box
Hit "Get Answer" and wait for the AI to respond

Try questions like:

"What is this document about?"
"Summarize the main points"


How to get different tech stacks to work together (harder than I thought!)
Integrating AI APIs into real applications
Building a proper microservices architecture
Managing state in React
Working with OpenAI's API and prompt engineering

The trickiest part was getting the services to communicate properly. CORS issues, API endpoints not matching up, making sure the AI got the right context - lots of debugging involved.
Tech stack

Backend: ASP.NET Core 8, Entity Framework Core, SQLite
AI Service: Python, FastAPI, OpenAI GPT-3.5
Frontend: React.js
Document Processing: PyPDF2 (for PDFs), python-docx (for Word files)

What's next?
Some ideas I'm thinking about:

Add document summarization
Support for more file types (maybe images with OCR?)
Compare multiple documents
Save Q&A history
Better error handling
Deploy it somewhere so people can actually use it

A few notes

You'll need to add your own OpenAI API key 
The free tier should be enough for testing
Documents are stored locally in a SQLite database

Issues or questions?
Found a bug? Have a question? Feel free to open an issue. I'm still learning so feedback is always welcome!
About me
I'm Pranay, a developer interested in AI and full-stack development. This is one of my learning projects where I'm combining different technologies to build something practical.

GitHub: @gattupranay
LinkedIn: https://www.linkedin.com/in/pranay-gattu-3025091a0/

If this helped you or you found it interesting, a ⭐ would be awesome!
