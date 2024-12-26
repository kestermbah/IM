Inventory Management (IM)
Overview
The Inventory Management (IM) project is a full-stack application designed to streamline store inventory operations. Built using C# and MAUI, the application provides dynamic inventory management features, including product selection, addition, deletion, and data persistence through a REST API and Filebase integration.

This project emphasizes modular code design and maintainability, making it easy to scale and enhance over time.

Features
Dynamic Inventory Management:
Add, update, and delete products in the inventory.
Dedicated deletion page for efficient item removal.
REST API Integration:
Dynamic data handling for seamless operations.
Data Persistence:
Filebase integration to store and retrieve inventory data persistently.
Code Modularity:
Designed for scalability and maintainability, ensuring ease of future development.
Technologies Used
Frontend: MAUI (Multi-platform App UI)
Backend: C# with REST API integration
Data Storage: Filebase for persistent storage
Development Tools:
Visual Studio
.NET Core SDK
Target Platforms:
Windows
Android
iOS
MacOS (via MAUI)
Installation and Setup
Backend
Clone the repository:
bash
Copy code
git clone https://github.com/kestermbah/IM.git
Navigate to the project folder:
bash
Copy code
cd IM/InventoryMaui
Open the project in Visual Studio.
Setup Dependencies
Ensure the following are installed:
Visual Studio with the MAUI workload
.NET Core SDK
Necessary platform SDKs (e.g., Android/iOS simulators, Windows development tools)
Run the Application
Build and run the project:
Select your target platform in Visual Studio (e.g., Windows, Android emulator).
Press F5 to build and debug the application.
Usage
Add Products:
Use the main interface to add new products to the inventory.
View and Manage Inventory:
View product lists with dynamic data loading.
Navigate to the deletion page to remove items.
Data Persistence:
Changes are stored in Filebase, ensuring inventory updates are saved and retrievable.
Future Plans
Authentication: Implement user authentication for secure access.
Cloud Storage: Expand data persistence using a more scalable cloud storage solution.
Analytics Dashboard: Provide visual insights into inventory trends and metrics.
Cross-Platform Enhancements: Refine the user experience on iOS and Android devices.
