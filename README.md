# 🤖 SmartDocQA - AI-Powered Document Q&A System

A full-stack microservices application that enables users to upload documents and ask natural language questions, receiving intelligent AI-powered answers.

[![GitHub](https://img.shields.io/badge/GitHub-SmartDocQA-blue)](https://github.com/gattupranay/SmartDocQA)
[![.NET](https://img.shields.io/badge/.NET-8.0-purple)](https://dotnet.microsoft.com/)
[![Python](https://img.shields.io/badge/Python-3.11-yellow)](https://www.python.org/)
[![React](https://img.shields.io/badge/React-18-blue)](https://reactjs.org/)

---

## 📋 Overview

SmartDocQA is an intelligent document analysis platform that combines modern web technologies with AI to provide an intuitive question-answering system. Users can upload documents in various formats and interact with them through natural language queries, powered by OpenAI's GPT models.

### Key Features

- 📤 **Multi-Format Support**: Upload PDF, DOCX, and TXT documents
- 🤖 **AI-Powered Q&A**: Natural language question answering using GPT-3.5
- 🔍 **Smart Text Extraction**: Automatic content extraction from various formats
- 💾 **Persistent Storage**: Document management with SQLite database
- ⚡ **Real-Time Processing**: Fast response times with optimized architecture
- 🎨 **Modern UI**: Clean, responsive React interface

---

## 🛠️ Tech Stack

### Backend (.NET Core)
- **ASP.NET Core 8** - Web API framework
- **Entity Framework Core** - ORM for database operations
- **SQLite** - Lightweight database
- **RESTful API** - Clean API architecture

### AI Service (Python)
- **FastAPI** - High-performance Python web framework
- **OpenAI GPT-3.5** - Natural language processing
- **PyPDF2** - PDF text extraction
- **python-docx** - Word document processing

### Frontend
- **React.js 18** - UI framework
- **Modern CSS3** - Responsive design
- **Fetch API** - RESTful communication

---

## 🏗️ Architecture

```
┌─────────────────┐
│   React UI      │  (Port 3000)
│   Frontend      │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  .NET Core API  │  (Port 5161)
│  Main Backend   │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│ Python FastAPI  │  (Port 8000)
│   AI Service    │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│   OpenAI API    │
│   GPT-3.5       │
└─────────────────┘
```

**Microservices Design:**
- **Frontend Layer**: Handles user interactions and display
- **API Gateway**: .NET Core manages requests, database, file storage
- **AI Service**: Python handles document processing and AI inference
- **External AI**: OpenAI provides natural language understanding

---

## 🚀 Getting Started

### Prerequisites

- **.NET SDK 8.0+** - [Download](https://dotnet.microsoft.com/download)
- **Python 3.11+** - [Download](https://www.python.org/downloads/)
- **Node.js 18+** - [Download](https://nodejs.org/)
- **OpenAI API Key** - [Get Key](https://platform.openai.com/api-keys)

### Installation

#### 1. Clone the Repository
```bash
git clone https://github.com/gattupranay/SmartDocQA.git
cd SmartDocQA
```

#### 2. Setup .NET API
```bash
cd DocAPI
dotnet restore
dotnet run
```
API will run on `http://localhost:5161`

#### 3. Setup Python AI Service
```bash
cd AIService
python -m venv venv
source venv/bin/activate  # On Mac/Linux
# OR
venv\Scripts\activate  # On Windows

pip install fastapi uvicorn openai python-multipart pypdf2 python-docx

# Add your OpenAI API key in main.py
# Then run:
python main.py
```
AI Service will run on `http://localhost:8000`

#### 4. Setup Frontend
```bash
cd frontend
npm install
npm start
```
Frontend will run on `http://localhost:3000`

---

## 💡 Usage

1. **Upload Document**: Click "Choose File" and select a PDF, DOCX, or TXT file
2. **Select Document**: Click on the uploaded document from the list
3. **Ask Question**: Type your question in natural language
4. **Get Answer**: Click "Get Answer" to receive AI-generated response

### Example Questions
- "What is this document about?"
- "Summarize the main points"
- "What are the key findings?"
- "Explain the methodology used"

---

## 📊 Database Schema

```sql
Documents Table:
├── Id (Primary Key)
├── FileName (String)
├── FilePath (String)
├── Content (Text - Extracted content)
└── UploadedAt (DateTime)
```

---

## 🎯 Skills Demonstrated

### Backend Development
✅ RESTful API Design  
✅ Microservices Architecture  
✅ Entity Framework Core ORM  
✅ Database Design & Management  
✅ File Upload Handling  

### AI/ML Integration
✅ OpenAI API Integration  
✅ Natural Language Processing  
✅ Document Text Extraction  
✅ Prompt Engineering  

### Frontend Development
✅ React.js Components  
✅ State Management  
✅ Responsive Design  
✅ API Integration  

### DevOps & Tools
✅ Git Version Control  
✅ Environment Configuration  
✅ Cross-platform Development  

---

## 🔮 Future Enhancements

- [ ] Multi-document comparison and analysis
- [ ] Document summarization feature
- [ ] Sentiment analysis
- [ ] Export Q&A history to PDF
- [ ] User authentication and authorization
- [ ] Cloud deployment (Azure/AWS)
- [ ] Vector database integration for semantic search
- [ ] Support for more document formats
- [ ] Batch document processing
- [ ] Advanced analytics dashboard

---

## 🤝 Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

---

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

---

## 👤 Author

**Pranay Gattu**

- GitHub: [@gattupranay](https://github.com/gattupranay)
- LinkedIn: [Add Your LinkedIn](https://linkedin.com/in/yourprofile)
- Portfolio: [Add Your Website]

---

## 🙏 Acknowledgments

- OpenAI for GPT API
- Microsoft for .NET Core
- FastAPI team for the excellent Python framework
- React community

---

## 📧 Contact

For questions or feedback, please open an issue or reach out via [your email].

---

**⭐ If you found this project helpful, please give it a star!**