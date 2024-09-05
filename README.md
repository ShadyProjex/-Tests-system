# Tests System

## Overview

This project is a **Tests System** developed using the **MVVM (Model-View-ViewModel)** design pattern in **C#** and **ASP.NET**. The system is designed to facilitate the creation, management, and evaluation of tests, providing a robust and scalable solution for educational or organizational purposes.

## Features

- **User Authentication:** Secure login and registration system.
- **Test Creation:** Admins can create and manage tests.
- **Question Bank:** A repository of questions categorized by subjects or topics.
- **Test Evaluation:** Automated scoring and detailed results for each test.
- **Responsive UI:** User-friendly interface with a focus on accessibility and performance.
- **Data Persistence:** Data stored using Entity Framework with support for SQL Server.

## Architecture

The project follows the MVVM architecture:

- **Model:** Defines the data structure and business logic. It includes the data access layer using Entity Framework.
- **View:** The UI components built using ASP.NET with support for Razor pages and data binding.
- **ViewModel:** Acts as a bridge between the View and the Model, handling data presentation and user interaction.

## Prerequisites

- **.NET SDK 6.0** or later
- **Visual Studio 2022** or later with ASP.NET and web development workloads installed
- **SQL Server** or any other compatible database system
- **Entity Framework Core**