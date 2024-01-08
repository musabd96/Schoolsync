# SchoolSync

SchoolSync is a comprehensive school management system that includes a React-based client application (SchoolSync.Client) for the frontend and an ASP.NET Core-based server (SchoolSync.Server) for the backend.

## Table of Contents

- [Getting Started](#getting-started)
  - [Installation](#installation)
    - [Dependencies](#dependencies)
  - [Running the Application](#running-the-application)
- [Project Structure](#project-structure)

## Getting Started

Follow the instructions below to set up and run the project on your local machine.

### Installation

#### Dependencies

1. **Install Node.js:**
   - Download and install Node.js from [https://nodejs.org/](https://nodejs.org/).

2. **Install .NET 8:**
   - Download and install .NET 8 from [https://dotnet.microsoft.com/download/dotnet/8.0](https://dotnet.microsoft.com/download/dotnet/8.0).

3. **Install Visual Studio:**
   - Download and install Visual Studio from [https://visualstudio.microsoft.com/](https://visualstudio.microsoft.com/).

4. **Clone the Repository:**
   - Clone SchoolSync repository to your local machine.
   ```bash
   https://github.com/musabd96/Schoolsync.git
   ```

### Running the Application

1. **Open the Solution:**
   - Open the solution file (SchoolSync.sln) in Visual Studio.

## Project Structure

The project is organized into two main components:

1. **SchoolSync.Client:**
    React application for the frontend.

2. **SchoolSync.Server:**
    ASP.NET Core application for the backend.
    - Api: ASP.NET Core API controllers.
    - Application: Application services and DTOs.
    - Domain: Core domain logic, entities, and repositories.
    - Infrastructure: Data access, external services, and configuration.
    