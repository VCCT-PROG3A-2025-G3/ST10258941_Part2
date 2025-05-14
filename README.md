🌿 Agri-Energy Connect
Agri-Energy Connect is an MVC-based web platform designed to bridge agriculture and green energy in South Africa. It empowers farmers by providing a marketplace for renewable energy solutions and a platform to sell their products, fostering sustainable practices and innovation.

🚀 Features
User Authentication: Secure login with role-based access for Farmers and Employees.
Farmer Dashboard: Add and manage products with details like name, category, and production date.
Employee Dashboard: Add new farmer profiles and view/filter products across all farmers.
Green Energy Marketplace: Access to renewable energy solutions tailored for agricultural needs.
Responsive Design: User-friendly interface adaptable to various devices.

🛠️ Technology Stack
Frontend: HTML, CSS
Backend: C# with ASP.NET MVC Framework
Database: SQL Server Management Studio (SSMS)
ORM: Entity Framework Core
Development Environment: Visual Studio

⚙️ Installation & Setup
Prerequisites
Visual Studio (latest version recommended)
.NET Framework
SQL Server Management Studio (SSMS)

Steps

Clone the Repository:
git clone https://github.com/LiamSteyn/Agri-Energy-Connect.git

Open the Project:
Open Agri-Energy Connect.sln in Visual Studio.

Restore NuGet Packages:
Visual Studio should automatically restore the necessary packages. If not, go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution... and restore them manually.

Configure the Database:
Open the appsettings.json file.
Update the connection string to point to your local SQL Server instance.

Apply Migrations:
Open the Package Manager Console and run 
Update-Database

Build and Run the Application:
Build the solution: Build > Build Solution or press Ctrl + Shift + B.
Run the application: Press F5 or click on the Start button.

👥 User Roles
Farmer:
Add and manage personal product listings.
View own products.

👥 Employee:
Add and manage farmer profiles.
View and filter products from all farmers based on criteria like date range and product type.
