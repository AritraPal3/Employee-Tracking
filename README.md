Employee-Tracking

Employee-Tracking is a full-stack application built using .NET architecture that follows the 3-Tier architecture pattern. It provides a comprehensive solution for maintaining various employees of an organization, including their personal details such as salary, tasks, permissions, and the ability to add new employees, tasks, and permissions. The application uses Microsoft SQL Server Management Studio to manage the underlying database.

Table of Contents:-
1. Project Overview
2. Technologies Used
3. Installation
4. Usage
5. Architecture

Project Overview
Employee-Tracking is a powerful application designed to simplify the management of employees in an organization. It provides a user-friendly interface to store and retrieve employee information, track their assigned tasks, manage permissions, and efficiently handle new employee onboarding.

Key features of the Employee-Tracking application include:

Employee management: Maintain a centralized database of employees, including their personal details, contact information, and salary information.
Task tracking: Assign and track tasks assigned to employees, including due dates, priorities, and completion status.
Permission management: Manage access permissions for employees, granting or revoking privileges based on their roles and responsibilities.
New employee onboarding: Streamline the process of adding new employees to the organization, including assigning tasks and setting permissions.
Database integration: The application seamlessly integrates with Microsoft SQL Server Management Studio to store and retrieve data securely.
Technologies Used
.NET Framework or .NET Core 
ASP.NET MVC or ASP.NET Core MVC 
Microsoft SQL Server Management Studio 
Entity Framework 
Installation
Clone the repository:
bash
Copy code: 
https://github.com/AritraPal3/Employee-Tracking.git

Usage
Visual Studio is requierd

Architecture
The Employee-Tracking application follows the 3-Tier architecture pattern, which separates the application into three logical layers:

Presentation Layer:

The presentation layer handles the user interface and user interactions.
It includes the ASP.NET MVC or ASP.NET Core MVC components responsible for rendering views and capturing user input.
The presentation layer communicates with the business layer to retrieve and display data to the user.

Business Layer:

The business layer contains the business logic and processing rules of the application.
It interacts with the presentation layer to handle user requests and provides the necessary data and functionality.
The business layer validates user input, performs data manipulation, and enforces business rules.

Data Access Layer:

The data access layer of the application utilizes the concept of DAO (Data Access Object) and DTO (Data Transfer Object).
The DAO pattern provides an abstraction layer between the application and the underlying database, encapsulating the database operations.
The DTO pattern defines data transfer objects that act as containers for transferring data between the different layers of the application.

Contributing
Contributions to the Employee-Tracking project are welcome! If you encounter any issues or have suggestions for improvements, please feel free to submit a pull request or create an issue in the GitHub repository.
