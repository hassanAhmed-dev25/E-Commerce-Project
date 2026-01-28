# 🛒 E-Commerce Web Application

🔗 Live Demo:  
👤 Admin Demo Account:  
- Email: admin@system.com  
- Password: Admin@1234

A modern E-Commerce web application built with ASP.NET Core MVC, designed using clean architecture (Onion Architecture) principles and real-world business workflows.

![.NET](https://img.shields.io/badge/.NET-8.0-purple?logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-blue?logo=microsoftsqlserver)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-purple?logo=bootstrap)

---

## 🚀 Why This Project?

This project was built to simulate a real-world e-commerce system, focusing on:
- Scalable backend architecture
- Secure authentication & authorization
- Clean separation of concerns
- Production-ready features, not just demos

---

## ✨ Key Features

### 🔐 Authentication & Authorization
- Secure authentication using ASP.NET Identity
- Login with Google (OAuth 2.0)
- Role-based access control (RBAC)

### 👥 User Roles

- Admin
  - Manage users, sellers
  - Approve seller requests
  - Full system access

- Seller
  - Manage products and inventory
  - View and process orders
  - Withdraw earnings from wallet
  - Track sales and balance

- Buyer
  - Browse products
  - Add items to cart
  - Place orders and make payments

---

### 💳 Wallet & Payment System

- Built-in wallet for each user
- Seller earnings credited automatically
- Withdrawal requests for sellers
- Transaction history tracking

---

### 🛍 E-Commerce Core Features

- Product catalog with categories
- Shopping cart & checkout flow
- Order management system
- Inventory tracking
- Multi-language support (Localization)

---

## 🏗 Architecture

The backend follows Clean Architecture(Onion Architecture), separating:
- Domain
- Application
- Infrastructure
- Presentation (MVC)

This ensures the codebase is:
- Maintainable
- Testable
- Scalable

### Backend Architecture (ASP.NET Core)

The backend is structured in layers following Clean Architecture principles:

```
## 📂 Project Structure

ECommerceProject
│
├── ECommerceProject.Domain
│   ├── Common
│   ├── Entities
│   └── Enums
│
├── ECommerceProject.Application
│   ├── Common
│   ├── DTOs
│   ├── Helper
│   ├── Interfaces
│   ├── Mapper
│   ├── Services
│   └── Validation
│
├── ECommerceProject.Infrastructure
│   ├── Common
│   ├── Configurations
│   ├── Data
│   ├── Identity
│   ├── Jobs
│   ├── Migrations
│   ├── Repositories
│   └── Services
│
├── ECommerceProject.MVC
│   ├── Controllers
│   ├── Languages
│   ├── Moddleware
│   ├── Models
│   ├── ViewModels
│   ├── Views
│   ├── appsettings.json
│   └── Program.cs
│ 
└── README.md
```

---

## 🛠 Tech Stack

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- Google OAuth
- Bootstrap

---

## 🚀 Getting Started


Before you begin, make sure thst you have the following installed:

- **.NET SDK 8.0** or later - [Download here](https://dotnet.microsoft.com/download)
- **SQL Server**  - [Download here](https://www.microsoft.com/sql-server/sql-server-downloads)
- **Git** - [Download here](https://git-scm.com/downloads)


#### 1. Clone the Repository

```bash
git clone https://github.com/hassanAhmed-dev25/E-Commerce-Project.git
cd E-Commerce-Project
```

#### 2. Backend Setup

```bash
# Restore NuGet packages
dotnet restore

# Update the connection string in appsettings.json
# Edit: E-Commerce-Project/ECommerceProject.MVC/appsettings.json
# Update the "DefaultConnection" string to match your SQL Server settings

# Apply database migrations
dotnet ef database update --project ECommerceProject.Infrastructure --startup-project ECommerceProject.MVC

# Run the Project
dotnet run --project ECommerceProject.MVC
```

The Website will be available at `https://localhost:44394`

### Default Access

After setup, you can access the application at `https://localhost:44394`. You can either:

- Register a new user account through the registration page
- Use default admin credentials
    - Email: admin@system.com
    - Password: Admin@1234



## 3. Features Setup

### 1) ✉️ Email Configuration
```bash
The application supports email notifications using SMTP.

# Update the email settings in appsettings.json:
# Edit: E-Commerce-Project/ECommerceProject.MVC/appsettings.json

"EmailSettings": {
    "From": "your-email@gmail.com",
    "SmtpServer": "smtp.gmail.com",
    "Port": 587,
    "UserName": "your-email@gmail.com",
    "Password": "your-email@gmail.com"
  },
}
```

### 2) 💳 Stripe Payment Integeration
```bash
The application integrates with Stripe to handle online payments and wallet top-ups.

Add your Stripe keys to appsettings.json:

# Update Stripe settings in appsettings.json:
# Edit: E-Commerce-Project/ECommerceProject.MVC/appsettings.json

"Stripe": {
    "SecretKey": "your_stripe_SecretKey",
    "PublishableKey": ""
  },
}
```

### 3) 🔐 Google Authentication
```bash
The application supports authentication using Google OAuth 2.0.

Steps:
1. Create OAuth credentials from Google Cloud Console
2. Add the credentials to appsettings.json:

# Update Authentication settings in appsettings.json:
# Edit: E-Commerce-Project/ECommerceProject.MVC/appsettings.json

"Authentication": {
  "Google": {
    "ClientId": "YOUR_GOOGLE_CLIENT_ID",
    "ClientSecret": "YOUR_GOOGLE_CLIENT_SECRET"
  }
}
```

## 📄 License

This project is licensed under the MIT License.


## 📧 Contact

For questions or support, please open an issue in the GitHub repository.