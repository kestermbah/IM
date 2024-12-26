# Amazon Inventory Management Demo (AIMD)

## Overview
The **Amazon Inventory Management Demo (AIMD)** project is a full-stack application designed to streamline store inventory operations. Built using **C#** and **MAUI**, the application provides dynamic inventory management features, including product selection, addition, deletion, and data persistence through a REST API and Filebase integration.

This project emphasizes modular code design and maintainability, making it easy to scale and enhance over time.

---

## Features
- **Dynamic Inventory Management**:
  - Add, update, and delete products in the inventory.
  - Dedicated deletion page for efficient item removal.
- **REST API Integration**:
  - Dynamic data handling for seamless operations.
- **Data Persistence**:
  - Filebase integration to store and retrieve inventory data persistently.
- **Code Modularity**:
  - Designed for scalability and maintainability, ensuring ease of future development.

---

## Technologies Used
- **Frontend**: MAUI (Multi-platform App UI)
- **Backend**: C# with REST API integration
- **Data Storage**: Filebase for persistent storage
- **Development Tools**:
  - Visual Studio
  - .NET Core SDK
- **Target Platforms**:
  - Windows
  - Android
  - iOS
  - MacOS (via MAUI)

---

## Installation and Setup

### Backend
1. Clone the repository:
   ```bash
   git clone https://github.com/kestermbah/IM.git

   ## Run the Application
1. Build and run the project:
   - Open the project in **Visual Studio**.
   - Select your target platform (e.g., Windows, Android emulator, iOS simulator).
   - Press **F5** to build and debug the application.
2. The application will launch on the selected platform, ready for use.

---

## Usage

### Add Products
- Use the main interface to add new products to the inventory by entering product details and saving them.

### View and Manage Inventory
- View the product list with dynamic data loading.
- Navigate to the **deletion page** to remove unwanted items from the inventory.

### Data Persistence
- All changes to the inventory are stored in **Filebase**, ensuring data remains consistent and retrievable across sessions.

---
