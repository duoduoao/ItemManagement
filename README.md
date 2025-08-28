ItemManagement System
The ItemManagement System is a retail and inventory management application built following Clean Architecture principles using .NET 8.0.
It provides a modular, maintainable, and extensible structure for handling inventory operations in different environments (development, testing, and production).

📌 Purpose & Scope
The goal of this system is to:
Provide a clean separation between UI, application logic, and domain entities.
Support multiple data storage providers (in-memory for testing, SQL Server for production).
Ensure scalability and maintainability.

🏗️ Architecture Overview
The solution follows Clean Architecture, separating concerns into distinct layers:
WebApp – ASP.NET Core web application (UI layer).
UseCases – Application layer responsible for business use case orchestration.
CoreBusiness – Domain layer containing entities and core business rules.
Plugins.DataStore.InMemory – In-memory data storage implementation (development/testing).
Plugins.DataStore.SQL – SQL Server data storage implementation (production).
Each layer follows dependency rules: outer layers depend only on inner layers.

📂 Project Structure
Project	Description	Dependencies
WebApp	ASP.NET Core web application providing the user interface	UseCases
UseCases	Application layer containing business logic orchestration	CoreBusiness
CoreBusiness	Domain layer with business entities and rules	None
Plugins.DataStore.InMemory	In-memory data storage for development/testing	CoreBusiness
Plugins.DataStore.SQL	SQL Server data storage for production	CoreBusiness


<img width="760" height="733" alt="image" src="https://github.com/user-attachments/assets/21d6e3df-c24f-42ec-a406-b352e5cd610f" />

