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
