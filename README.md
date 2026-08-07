# 🚀 URL Shortener API

A lightweight, robust, and containerized URL Shortening RESTful API built with **.NET 10**, **Entity Framework Core**, and **SQLite**. Designed with clean architecture principles, comprehensive unit testing, and Docker support.

---

## 🌟 Features

* **Shorten URLs**: Send a long URL and receive a unique, shortened code/link.
* **Redirection**: Seamlessly redirects requests from the short code to the original long URL.
* **In-Memory & File-Based Persistence**: Uses Entity Framework Core with SQLite for fast, reliable data storage.
* **Unit Tested**: Comprehensive test suite using **xUnit** and SQLite In-Memory databases implementing the **AAA Pattern** (Arrange, Act, Assert).
* **Containerized**: Fully packaged with a production-ready multi-stage **Docker** image for easy deployment anywhere.

---

## 🛠️ Tech Stack

* **Language**: C# / .NET 10
* **Framework**: ASP.NET Core Web API
* **Database**: SQLite & EF Core
* **Testing**: xUnit
* **Containerization**: Docker

---

## 📁 Project Structure

```text
UrlShortener/
│
├── UrlShortener.Api/         # Main Web API project
│   ├── Endpoints/          # API Endpoints
│   ├── Data/                 # EF Core DbContext & Models
│   ├── Services/             # Business logic layer
│   ├── Dockerfile            # Multi-stage production Dockerfile
│   └── .dockerignore         # Docker ignore rules
│
├── UrlShortener.Tests/       # Unit Test project (xUnit)
│   └── UrlShorteningServiceTests.cs
│
└── UrlShortener.sln          # Solution file
```

---

## 🚀 Getting Started Locally

### Prerequisites
* .NET 8 SDK installed on your machine.
* Docker Desktop (optional, if running via container).

### Running via .NET CLI
1. Clone the repository:
```bash
git clone https://github.com/TiaanVanRooyen/UrlShortener.git
cd UrlShortener
```
2. Restore dependencies and run the API:
```bash
dotnet run --project UrlShortener.Api/UrlShortener.Api.csproj
```
3. The API will start on http://localhost:5000 (or the assigned local port).

## 🐳 Running with Docker
To run the application inside a self-contained Docker container:

1. Build the Docker image from the API directory:
```bash
docker build -t url-shortener-api -f UrlShortener.Api/Dockerfile UrlShortener.Api/
```
2. Run the container:
```bash
docker run -d -p 8080:8080 --name my-running-shortener url-shortener-api
```
3. Access the API locally at http://localhost:8080.

---

## 🧪 Running Tests
To execute the unit test suite, run the following command from the root solution directory:

```bash
dotnet test
```

---

## 💡 What I Learned
* Designing and structuring a clean ASP.NET Core REST API following separation of concerns.

* Writing robust unit tests with xUnit using isolated in-memory databases.

* Containerizing .NET applications using multi-stage Dockerfiles and managing runtime environments, file permissions, and port mappings.
