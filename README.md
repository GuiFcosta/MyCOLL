# MyCOLL - Collectibles Marketplace Platform 🪙📦

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![MAUI](https://img.shields.io/badge/MAUI-Multi--Platform-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

**MyCOLL** is a robust cross-platform solution developed for buying and selling collectibles (Numismatics, Philately, and others). It features a unified ecosystem allowing Suppliers to manage their inventory and Sales, and Clients to browse and purchase items seamlessly across Web and Mobile devices.

## 🚀 Key Features

### 🛒 For Clients
- **Product Browsing:** Filter items by category (Coins, Stamps, etc.), price, and condition.
- **Shopping Cart:** Add items, manage quantities, and proceed to checkout.
- **Order Management:** View full order history with status tracking (Pending, Paid, Shipped, Delivered).
- **Order Details:** Detailed view of purchased items, quantities, and totals.
- **Cross-Platform:** Access the same account and cart from the Web or Mobile App.

### 📦 For Suppliers
- **Product Management:** Create, edit, and delete products with image support (Base64 handling).
- **Stock Control:** Real-time stock updates. Automatic deduction upon shipment.
- **Sales Dashboard:** View sales history, calculate total revenue, and track items sold.
- **Order Fulfillment:** Confirm payments, ship orders, and handle cancellations (with stock rollback logic).

### 🔐 Security & Architecture
- **Authentication:** JWT (JSON Web Tokens) based authentication.
- **Role-Based Access Control (RBAC):** Distinct roles for `Admin`, `Supplier`, and `Client`.
- **Clean Architecture:** Separation of concerns using specific projects for API, Data, and UI.

---

## 🏗️ Project Structure

The solution follows a modular architecture sharing 90% of the UI code between Web and Mobile:

- **`MyCOLL`**: ASP.NET Core Web API (.NET 8). Handles business logic, database access (EF Core), auth, and file storage.
- **`MyCOLL.Shared` (Razor Class Library)**: The heart of the frontend. Contains all **Pages** (Home, Cart, Products, Orders) and **Components**. Shared between Web and App.
- **`MyCOLL.App`**: .NET MAUI project. Wraps the RCL to run natively on Android and Windows.
- **`MyCOLL.Web`**: Blazor WebAssembly Standalone. Wraps the RCL to run in the browser.
- **`MyCOLL.Data`**: Contains Entity Framework Core contexts, Database Migrations, and Entities.

---

## 🛠️ Technology Stack

- **Framework:** .NET 8
- **Backend:** ASP.NET Core Web API
- **Database:** SQL Server (Entity Framework Core Code-First)
- **Frontend (Web):** Blazor WebAssembly
- **Frontend (Mobile):** .NET MAUI (Hybrid)
- **Authentication:** ASP.NET Core Identity + JWT Bearer
- **Storage:** Local file storage for images (mapped via API static files)

---

## ⚙️ Getting Started

### Prerequisites
- Visual Studio 2022 or JetBrains Rider
- .NET 8 SDK
- SQL Server (LocalDB or Full Instance)

### 1. Database Setup
1. Configure your connection string in `MyCOLL.API/appsettings.json`.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyCOLLdb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   
### 2. Running the API
- Set MyCOLL as the startup project and run it.
- It usually runs on https://localhost:7004 (check launchSettings.json).

### 3. Running the Frontend
- Web: Set MyCOLL.Web as startup and run.
- Mobile: Set MyCOLL.App as startup, select an Emulator (Android) or Windows Machine, and run.

### Authors
- Guilherme Costa (2022144234)
- Rodrigo Braga (2023135350)

Project developed for the Web Programming (PWEB) course at ISEC - Coimbra Institute of Engineering.
