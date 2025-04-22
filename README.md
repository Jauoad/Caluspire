## License

This project is licensed under the Creative Commons Attribution-NonCommercial 4.0 International (CC BY-NC 4.0) License - see the [LICENSE](LICENSE) file for details.

# 📦 Caluspire

**Caluspire** is a modern, scalable, and modular job application platform built with **.NET Aspire**. It leverages clean architecture principles, CQRS, DDD, SignalR, and GraphQL to deliver a flexible backend for managing job postings and applications.

---

## 🧠 Core Concepts & Architecture

| Layer                      | Responsibilities                                                            |
|---------------------------|------------------------------------------------------------------------------|
| `Caluspire.Domain`        | Domain Models, Entities, Interfaces following DDD principles                 |
| `Caluspire.Application`   | Business logic: CQRS (Commands, Queries, Handlers), DTOs                    |
| `Caluspire.Infrastructure`| Data access layer: EF Core, Repository Pattern                              |
| `Caluspire.ApiService`    | Exposes REST + GraphQL APIs, SignalR for real-time communication            |
| `Caluspire.Web`           | Frontend placeholder (for Blazor/React app)                                 |
| `Caluspire.AppHost`       | Hosting entry point (via .NET Aspire)                                       |
| `Caluspire.ServiceDefaults`| Shared service configurations for Aspire ecosystem                          |
| `Caluspire.Tests`         | Unit and integration test support                                           |
| `Caluspire.AI`            | AI and Machine Learning for data processing, predictions, model integration |

---

## ⚙️ Technologies & Frameworks

| Stack               | Description                               |
|---------------------|-------------------------------------------|
| **.NET 8/9 + Aspire** | Modern .NET microservice hosting          |
| **MediatR**         | CQRS and in-process messaging              |
| **Entity Framework Core** | ORM with in-memory DB (demo)          |
| **HotChocolate**    | GraphQL for .NET                          |
| **SignalR**         | Real-time notifications for applications |
| **Minimal API**     | Lightweight REST setup in ASP.NET Core   |
| **React**                | Frontend framework for building user interfaces            |
| **PostgreSQL**      | Relational database system used for data storage           |
| **AutoMapper**      | Object-object mapping to streamline data transfer          |
| **ML.NET**          | Machine Learning tools for building AI models and predictions |


---

## 🧱 Design Patterns & Principles

- **CQRS** with MediatR (Separation of Read/Write)
- **Domain-Driven Design (DDD)**: Aggregates, Entities, Value Objects
- **Repository Pattern**: Abstracted data access
- **Dependency Injection**: Service lifetimes configured with `AddScoped`
- **SOLID Principles**: Highly modular and testable architecture

---

## 📂 Project Structure Overview

- **Caluspire/**
  - **Caluspire.ApiService/** 📡 Exposes REST APIs, GraphQL (HotChocolate), and SignalR Hubs
    - `Program.cs`: Configures endpoints, Mediator, GraphQL, SignalR
  - **Caluspire.Application/** 🧠 Contains business logic and application rules
    - **Commands/**: Commands for write operations (CQRS)
    - **Queries/**: Queries for read operations (CQRS)
    - **Handlers/**: MediatR handlers that process commands and queries
    - **DTOs/**: Data Transfer Objects for API/GraphQL communication
    - **Repositories/**: Abstractions for persistence layer
  - **Caluspire.Domain/** 📘 Domain layer following DDD
    - **Entities/**: Aggregates like Job and Candidate
    - **Repositories/**: Interfaces like IJobRepository, decoupled from infrastructure
  - **Caluspire.Infrastructure/** 🏗️ Implements EF Core persistence and repositories
    - **Persistence/**: DbContext + repository classes using EF Core
    - **Repositories/**: Concrete repository implementations
  - **Caluspire.Web/** 🌐 Frontend application placeholder (for Blazor or React)
    - *(empty for now)*: Future UI development
  - **Caluspire.ServiceDefaults/** ⚙️ Reusable service registration defaults for Aspire
  - **Caluspire.AppHost/** 🚀 App hosting configuration using .NET Aspire
    - `Program.cs`: Application orchestration and startup
  - **Caluspire.Tests/** ✅ Unit/integration tests (to be implemented)
    - `WebTests.cs`: Placeholder for future tests
 - **Caluspire.AI/** App for AI/ML models and algorithms for advanced decision-making
   - **Data/**: Contains raw data input and pre-processing tools used by ML models
   - **Helpers/**: Includes helper functions to aid with model training, evaluation, and testing
   - **Models/**: Stores machine learning models, including trained models, algorithms, and configurations
   - **Services/**: Provides services for running AI models, predictions, and managing model life cycle


---

## 🚀 How to Run the Project

> Caluspire uses .NET Aspire and a modular architecture. The backend exposes endpoints via REST, GraphQL, and SignalR.

### 🛠️ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- ASP.NET Core Runtime
- (Optional) [Docker](https://www.docker.com/) for future scalability

### ✅ Run the Project

```bash
# Clone the repository
git clone https://github.com/Jauoad/Caluspire.git
cd Caluspire

# Restore dependencies
dotnet restore

# Run the backend services (via AppHost)
dotnet run --project Caluspire.AppHost


