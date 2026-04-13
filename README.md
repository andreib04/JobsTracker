# 🚀 JobsTracker API

A full-featured backend API built with ASP.NET Core following Clean Architecture principles, designed to help users track and manage their job applications efficiently.

---

## 📌 Overview

JobsTracker is a personal project that simulates a real-world production-ready backend system. It allows users to:

- Register & authenticate securely
- Track job applications
- Manage companies
- Add notes to applications
- Monitor application progress

---

## 🏗️ Architecture

This project follows Clean Architecture:
---
```
JobsTracker
├── JobsTracker.API            → Presentation layer (Controllers, Middleware)
├── JobsTracker.Application    → Business logic (Services, DTOs, Validators)
├── JobsTracker.Domain         → Core domain (Entities, Interfaces)
└── JobsTracker.Infrastructure → Data access (EF Core, Repositories)
```

## ⚙️ Tech Stack

- .NET 8 (LTS)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- FluentValidation
- Serilog (Logging)
- Swagger (OpenAPI)

---

## 🔐 Features

### ✅ Authentication
- User registration & login
- JWT-based authentication
- Secure protected endpoints

### 💼 Job Management
- Create, update, delete job applications
- Track job status
- Link applications to companies

### 🏢 Company Management
- Store and manage companies
- Enforce relational integrity

### 📝 Notes
- Add notes to job applications

### 🛠️ Advanced Backend Features
- ✅ Clean Architecture separation of concerns
- ✅ Global exception handling middleware
- ✅ Standardized API responses
- ✅ Request validation using FluentValidation
- ✅ Structured logging (console + file) with Serilog
- ✅ Dependency Injection across layers

---

## 📊 Logging

Logs are written to:
```
/logs/log-<date>.txt
```

Includes:

- Info logs (user actions)
- Warnings (invalid behavior)
- Errors (exceptions with stack traces)

---

## 🔄 API Response Format

All responses follow a consistent structure:

```json
{
  "success": true,
  "message": "Operation successful",
  "data": {}
}
```

Validation errors:

```json
{
  "success": false,
  "message": "Validation failed",
  "errors": {
    "Field": ["Error message"]
  }
}
```

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/YOUR_USERNAME/JobsTracker.git
cd JobsTracker
```

### 2. Configure database

Update `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "your-sql-server-connection"
}
```

### 3. Apply migrations

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

### 5. Open Swagger

```
https://localhost:<port>/swagger
```

Use the **Authorize** button to test secured endpoints.

---

## 🔑 Authentication (Swagger)

1. Register a user
2. Login → copy JWT token
3. Click **Authorize** in Swagger
4. Enter:
```
Bearer YOUR_TOKEN
```
---

## 🧪 Testing

You can test endpoints via:

- Swagger UI
- Postman

---

## 📌 Project Status

✅ Backend complete
🚧 Frontend (Angular) — coming next

---

## 📈 Future Improvements

- Angular frontend (dashboard, UI)
- Pagination & filtering
- Role-based authorization
- File uploads (CVs)
- Email notifications
- Deployment (Docker / Cloud)

---

## 👨‍💻 Author

Built as a personal project to simulate a real-world production-ready system and strengthen full-stack development skills.

---

## ⭐️ If you like this project

Give it a star ⭐ on GitHub!