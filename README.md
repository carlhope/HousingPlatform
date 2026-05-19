# 🏗️ Housing Platform API (Work in Progress)

A small but modern backend demonstrating clean architecture, vertical slice design, domain‑driven modelling, distributed caching, and event‑driven messaging.
The domain is intentionally simple — the focus is on showcasing engineering patterns rather than building a full product.

---

## 🚀 Tech Stack

- **.NET 10** - Minimal APIs
- **Vertical Slice Architecture** (MediatR + feature folders)
- **DDD-inspired domain modelling**
- **PostgreSQL** (EF Core)
- **Redis** - distributed caching
- **RabbitMQ** - event-driven messaging
- **Azure Functions** - async processing of published events
- **Docker Compose** (Postgres database, RabbitMQ, Redis)
- **FluentValidation**

---

## 📦 Current Features

**API & Application Layer**
- CRUD endpoints (Create, Read, Update, Delete)
- Clean vertical slice structure (commands, queries, validators)
- Minimal API endpoints with clear separation of concerns

**Domain Layer**
- Rent represented as a temporal history of charges and payments
- Tenancy balance derived from domain rules
- Domain events prepared for future event‑driven workflows

**Infrastructure**
- PostgreSQL via EF Core
- Redis‑backed caching
- RabbitMQ integration (publisher + test consumer)
- Azure Function that reacts to published events
- Dockerised infrastructure (API + PostgreSQL + Redis + RabbitMQ)

---

## 🔄 Event‑Driven Workflow
The system includes a simple but real asynchronous flow:

- **API publishes** a PropertyCreatedEvent
- **RabbitMQ routes the event**
- **Azure Function** processes the event and performs downstream logic

This demonstrates a decoupled, production‑style event pipeline.

## 🧭 Roadmap (Upcoming)

These features are planned but not yet implemented:

- Authentication & role-based access
- Improved caching strategy (tag-based or event-driven)
- Expanded logging & observability
- More event-driven workflows

---

## 🛠️ Running Locally

This project requires the following services to be running:

- **PostgreSQL** (provided via Docker Compose)
- **Redis** (for distributed caching)
- **RabbitMQ** (for messaging queues)

---

### 1. Start PostgreSQL (Dockerised)

A ready‑to‑use Docker container is included in the repository under the `docker` directory.

From the `docker` folder:

```bash
docker compose up -d
```
Ensure docker container is running.

### 3. Run the API

Use your IDE or:

```bash
dotnet run --project Housing.Api
```

The API will be available at:

```
http://localhost:5160
```


---

## 🎯 Project Purpose

This repository is designed as a **technical showcase**, focusing on:

- Clean, maintainable backend architecture  
- Integration of multiple infrastructure components  
- Practical use of Redis caching  
- Event-driven patterns 
- Demonstrating backend engineering beyond CRUD  

The domain will grow gradually, but the emphasis is on architectural clarity and real-world patterns.

---
