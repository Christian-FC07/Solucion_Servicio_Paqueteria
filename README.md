# Package service

Package tracking system. It allows users to monitor every phase, from the point of origin to final delivery.

# Package Tracking System

# Description

This is an academic project developed to simulate the lifecycle of a package, from its entry into the system to its final delivery. It allows you to view the different state transitions, such as "In Warehouse," "In Transit," "In Customs," "Out for Delivery," and "Delivered."

# Technologies Used

Visual Studio: Development environment.

.NET Framework: Framework for building the application.

C#: Main programming language.

SQL Server Management Studio: For managing the database that stores package information and their statuses.

# Features

Package Creation: Registering new shipments in the system. (Does not handle the purchase or transition of the purchase)

Status Update: Ability to change a package's status as it progresses along its route.

Inquiry: Searching for and viewing the current status of any package.

# How to Use

To run this project, you need to have the mentioned technologies installed.

Clone the repository:

git clone https://github.com/Christian-FC07/Package-service.git

# Configure the database:

Open SQL Server Management Studio.

Create a database named Servicio_Paqueteria.

Execute the SQL scripts located in the folder to create the necessary tables.

# Open the project in Visual Studio:

Navigate to the project folder and open the .sln solution file.

# Run the application:

Press F5 in Visual Studio to compile and run the project.
