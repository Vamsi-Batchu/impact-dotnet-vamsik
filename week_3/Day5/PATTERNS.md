# Week 3 - Design Patterns Mapping (PATTERNS.md)

This document maps all design patterns implemented and discussed during Week 3 to their corresponding usage in future software layers.

| Design Pattern | Category | Project Implementation / Location | Where it Appears Later in Course / Enterprise Architecture |
| :--- | :--- | :--- | :--- |
| **Singleton** | Creational | `Day2/Task3.4_Singleton` | **Service Lifecycle & Configuration**: Dependency Injection containers (e.g., ASP.NET Core `AddSingleton`), database connection pools, and logging services. |
| **Factory / Factory Method** | Creational | `Day2/Task3.5_Factory` | **Service Creation & Frameworks**: Object instantiation in web frameworks, `IHttpClientFactory` creation, ORM entity factories, and dynamic plugin loaders. |
| **Observer** | Behavioral | `Day2/Task3.6_Observer` | **Event-Driven Architecture**: C# `event` models, UI frameworks (WPF/Blazor data binding), message buses (RabbitMQ, Kafka), and MediatR domain events. |
| **Strategy** | Behavioral | `Day3/Task3.7_Strategy` | **Runtime Behavior Selection**: Payment gateway integrations, customizable tax/discount calculation algorithms, dynamic sorting, and authentication handlers. |
| **Repository** | Structural / Data | `Day3/Task3.8_RepositoryUoW` | **Data Access Layer**: Abstraction of database operations (Entity Framework Core DbContext/DbSet) decoupling persistence logic from domain code. |
| **Unit of Work** | Architectural | `Day3/Task3.8_RepositoryUoW` | **Transaction Management**: Coordinates atomic operations across multiple repositories into a single transaction / `SaveChanges()` call. |
| **Adapter** | Structural | `Day3/Task3.9_AdapterFacade` | **Third-Party Integration**: Wrapping legacy APIs, converting external XML/JSON payloads to internal domain models without modifying core code. |
| **Facade** | Structural | `Day3/Task3.9_AdapterFacade` | **Microservice API Gateway / Subsystem Orchestration**: Providing simplified high-level entry points (e.g., `PlaceOrder`) over complex multi-service workflows. |
| **Builder** | Creational | Short Notes (Task 3.9) | **Complex Object Construction**: Test data builders, ASP.NET Core `WebApplicationBuilder`, and fluent configuration APIs. |
| **Prototype** | Creational | Short Notes (Task 3.9) | **Object Cloning**: In-memory caching, prototype bean scopes, and cloning complex graphics/document objects. |
| **Decorator** | Structural | Short Notes (Task 3.9) | **Cross-Cutting Concerns**: Middleware pipelines, caching wrappers around services, and logging/validation decorators. |
| **Command** | Behavioral | Short Notes (Task 3.9) | **Task Scheduling & Undo/Redo**: CQRS pattern (`IRequest` in MediatR), background task queuing, and transaction logging. |
| **Template Method** | Behavioral | Short Notes (Task 3.9) | **Framework Lifecycle Hooks**: ASP.NET Core controller base execution, ETL pipeline base templates, and data import processors. |
| **Mediator** | Behavioral | Short Notes (Task 3.9) | **Decoupled Communication**: MediatR in Clean Architecture for separating controllers from application logic. |
| **Chain of Responsibility**| Behavioral | Short Notes (Task 3.9) | **Request Processing Pipelines**: HTTP Middleware pipelines, authentication/authorization chains, and validation rules. |
| **State** | Behavioral | Short Notes (Task 3.9) | **Workflow / Order Management**: Finite state machines for order statuses (Draft, Submitted, Shipped, Cancelled). |
