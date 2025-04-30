# OperateR

OperateR is a lightweight and extensible mediator-based library built with C# to handle events, commands, and notifications in a clean and decoupled manner. Inspired by the mediator pattern, this project helps to organize application logic into small, testable components.

## 🧱 Project Structure

- **Core/**
  - `Mediator.cs` – The central mediator logic implementation.
  
- **Extensions/**
  - `ServiceCollectionExtensions.cs` – Extension methods for registering services into the .NET dependency injection container.
  
- **Interfaces/**
  - `IEvent`, `IEventHandler` – Interfaces for event publishing and handling.
  - `INotification`, `INotificationHandler` – For managing notification messages.
  - `IMediator`, `IHandler`, `IOperation`, `IPipelineBehavior` – Abstractions used for command handling, behavior chaining, and decoupling logic.

## ✅ Features

- Lightweight and clean implementation of the Mediator pattern.
- Supports commands, events, notifications, and behaviors.
- Easy integration with ASP.NET Core via dependency injection.
- Clear separation of concerns for better testability and maintainability.

## 🚀 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/OperateR.git
   Add the project to your solution.

2. Add the project to your solution.
3. Use the extension method AddOperateR() to register the required services:
   services.AddOperateR();

📌 Goals
- Promote clean architecture.
- Simplify cross-cutting concerns with pipeline behaviors.
- Provide an extensible base for CQRS and event-driven architecture.

📄 License
This project is open-source and available under the MIT License.
