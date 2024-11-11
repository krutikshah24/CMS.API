# Contact Management System

This application uses a .NET Core API for the backend and an Angular application for the frontend. The backend data is stored in a JSON file, and the application includes server-side pagination to handle large datasets efficiently.

This repository contains
---

## Table of Contents

1.1. [Repositories](#repositories)
2. [Setup Instructions](#setup-instructions)
   - [.NET Backend](#net-backend)
   - [Angular Frontend](#angular-frontend)
3. [How to Run the Application](#how-to-run-the-application)
4. [Application Structure](#design-decisions-and-application-structure)

---

## Repositories

1. **Backend (API)**: [https://github.com/krutikshah24/CMS.API]
2. **Frontend (UI)**: [https://github.com/krutikshah24/CMS.UI]

Clone each repository separately and follow the setup instructions below for each project.

---

## Setup Instructions

To set up this project, you must configure both the backend and frontend environments.

### .NET Backend

1. **Install .NET SDK**:
   - Download and install the [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher).
     
2. **Restore Dependencies**:
   - In the backend project folder, run the following command to restore necessary NuGet packages:
     ```bash
     dotnet restore
     ```
3. **Build the Project**:
   - To ensure all components are correctly built, run:
     ```bash
     dotnet build
     ```

### Angular Frontend

1. **Install Node.js and Angular CLI**:
   - Download and install [Node.js](https://nodejs.org/) (LTS version recommended).
   - Install the Angular CLI globally by running:
     ```bash
     npm install -g @angular/cli
     ```
   - Confirm the installation by running:
     ```bash
     ng version
     ```

2. **Navigate to the Angular Project Directory**:
   - Move into the `angular-client` directory where the Angular code is located.

3. **Install Dependencies**:
   - Install the required npm packages by running:
     ```bash
     npm install
     ```
---

## How to Run the Application

### Run the .NET Backend

1. **Navigate to the Backend Project Directory**:
   - Open a terminal and navigate to the backend project directory.

2. **Start the API**:
   - Run the backend API with the following command:
     ```bash
     dotnet run
     ```
   - The API should now be accessible at `https://localhost:7130`. This endpoint serves as the base URL for all API requests.

### Run the Angular Frontend

1. **Navigate to the Angular Project Directory**:
   - Open a new terminal and navigate to the `angular-client` directory.

2. **Start the Angular Application**:
   - Run the Angular frontend with the following command:
     ```bash
     ng serve
     ```
   - The application should now be accessible at `http://localhost:4200`. The Angular application will use the backend API to perform CRUD operations.

---

## Application Structure

#### Backend (.NET Core)

- **Controllers**: The `UserController` serves as the main API controller. It handles HTTP requests for CRUD operations and routes them to the `UserService`.
- **Services**: The `UserService` implements the main business logic, performing CRUD operations on the user data. It communicates with a repository layer for data access.
- **Models**: The `User` model represents the data schema for users, defining the properties and validation rules (e.g., required fields and email format).

#### Frontend (Angular)

- **Components**:
   - `UserListComponent`: Displays a list of users with pagination controls for easy navigation.
   - `UserFormComponent`: Handles user creation and update operations, with form validation for required fields and email format.
- **Services**:
   - `UserService`: An Angular service that uses `HttpClient` to send HTTP requests to the backend API, providing methods for CRUD operations.
- **Models**:
   - A TypeScript interface defines the structure of the `User` model in the frontend, ensuring consistency with the backend data schema.
- **Pagination**:
   - The frontend requests data in pages from the backend, enabling server-side pagination for optimized data handling.

---
