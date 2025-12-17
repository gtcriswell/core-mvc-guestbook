# .NET Core Guestbook Application

A modern, full-stack guestbook application built with .NET 10, demonstrating clean architecture principles and contemporary web development practices.

## 🏗️ Architecture

This solution implements a **3-tier architecture** with clear separation of concerns:

- **API Layer** - RESTful Web API for backend operations
- **Web Layer** - ASP.NET Core MVC frontend with Razor views
- **Data Layer** - Repository pattern with Dapper ORM
- **Services Layer** - HTTP client services for API communication
- **Tests Layer** - Comprehensive unit and integration tests

## 🚀 Technologies & Frameworks

### Backend
- **.NET 10** - Latest .NET framework
- **C# 14.0** - Modern C# language features
- **ASP.NET Core Web API** - RESTful API endpoints
- **Dapper** - Lightweight ORM for high-performance data access
- **SQL Server** - Database with LocalDB support
- **Swagger/OpenAPI** - API documentation and testing

### Frontend
- **ASP.NET Core MVC** - Server-side rendering
- **Razor Pages** - Dynamic view generation
- **Bootstrap 5** - Responsive UI framework
- **Vanilla JavaScript** - AJAX operations for seamless UX
- **jQuery** - DOM manipulation and validation

### Testing
- **xUnit** - Testing framework
- **Moq** - Mocking framework for unit tests
- **FluentAssertions** - Fluent assertion library
- **Integration Tests** - Database integration testing

### Design Patterns
- **Repository Pattern** - Data access abstraction
- **Dependency Injection** - Built-in ASP.NET Core DI
- **DTO Pattern** - Data transfer objects for API communication
- **Service Layer Pattern** - Business logic encapsulation
- **Factory Pattern** - IHttpClientFactory for HTTP operations

## ✨ Features

- ✅ **CRUD Operations** - Create, Read, Update, Delete guestbook entries
- ✅ **AJAX-Driven UI** - Partial page updates without full reloads
- ✅ **RESTful API** - Clean API endpoints with proper HTTP verbs
- ✅ **Modal Editing** - Bootstrap modals for entry updates
- ✅ **Confirmation Dialogs** - User-friendly delete confirmations
- ✅ **Responsive Design** - Mobile-friendly interface
- ✅ **Async/Await** - Full asynchronous operation support
- ✅ **Cancellation Tokens** - Proper cancellation support for HTTP requests
- ✅ **Anti-Forgery Tokens** - CSRF protection on forms
- ✅ **Comprehensive Testing** - Unit and integration test coverage

## 📁 Project Structure

## 🎯 Key Technical Highlights

### API Layer
- RESTful endpoints with attribute routing
- OpenAPI/Swagger documentation
- Dependency injection for repositories
- Proper HTTP status codes

### Data Access
- Dapper for efficient SQL execution
- Raw SQL queries with parameter binding
- Connection string configuration
- SCOPE_IDENTITY for retrieving inserted IDs

### Frontend Integration
- HttpClient with IHttpClientFactory
- JSON serialization with System.Text.Json
- Cancellation token propagation
- Error handling and fallback responses

### Testing Strategy
- Mocked dependencies for unit tests
- HttpMessageHandler mocking for HTTP tests
- AAA (Arrange-Act-Assert) pattern
- FluentAssertions for readable test assertions

## 🛠️ Getting Started

### Prerequisites
- .NET 10 SDK
- SQL Server or LocalDB
- Visual Studio 2022 or VS Code

### Configuration
1. Update connection string in `API/appsettings.json`
2. Update API URL in `Web/appsettings.json`
3. Run database migrations/scripts

### Running the Application

## 📊 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/guestbook/entries` | Get all guestbook entries |
| POST | `/api/guestbook/entry` | Create a new entry |
| PUT | `/api/guestbook/entry` | Update an existing entry |
| DELETE | `/api/guestbook/entry?id={id}` | Delete an entry |

## 🧪 Test Coverage

- **6 Controller Tests** - API endpoint validation
- **6 Repository Tests** - Data access layer testing
- **11 Service Tests** - HTTP client and error handling

## 📝 License

This project is open source and available under the MIT License.

## 👨‍💻 Author

**gtcriswell**

---

*Built with ❤️ using .NET 10 and modern web technologies*
