# 🏗️ Housing Platform API (Work in Progress)

A small but modern backend demonstrating clean architecture, vertical slice design, distributed caching, and containerised infrastructure.  
The domain is intentionally simple — the focus is on showcasing engineering patterns rather than building a full product.

---

## 🚀 Tech Stack

- **.NET 10 Minimal APIs**
- **Vertical Slice Architecture** (MediatR + feature folders)
- **PostgreSQL** (EF Core)
- **Redis** (distributed caching)
- **Docker** (Postgres database)
- **FluentValidation**

---

## 📦 Current Features

- Property CRUD (Create, Read, Update, Delete)
- Redis-backed caching
- Clean vertical slice structure
- Dockerised infrastructure (API + PostgreSQL + Redis)
- Basic domain modelling
- - **Early rent domain modelling**  
  - Rent is represented as a **temporal history** of charges and payments  
  - Tenancy balance is calculated from `RentCharges` and `RentPayments`  
  - No endpoints yet — domain logic only, demonstrating DDD-style modelling

---

## 🧭 Roadmap (Upcoming)

These features are planned but not yet implemented:

- Event‑driven architecture using **RabbitMQ**
  - Cache invalidation worker
  - Domain event publishing
- Tenancy lifecycle modelling
- Authentication & role-based access
- Additional domain entities (Landlords, Owners, Tenancies)
- Improved caching strategy (tag-based or event-driven)
- Expanded logging & observability

---

## 🛠️ Running Locally

This project requires the following services to be running:

- **PostgreSQL** (any version supported by EF Core)
- **Redis** (for distributed caching)


### 1. Ensure PostgreSQL is running

Update the connection string in `appsettings.json` to point to your PostgreSQL instance.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=Housing;Username=postgres;Password=yourpassword"
}
```

### 2. Ensure Redis is running

The API expects a Redis instance reachable at the connection string defined in configuration.

Example:

```json
"Redis": {
  "ConnectionString": "localhost:6379"
}
```

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
- Event-driven patterns (planned)  
- Demonstrating backend engineering beyond CRUD  

The domain will grow gradually, but the emphasis is on architectural clarity and real-world patterns.

---
