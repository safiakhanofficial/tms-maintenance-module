# TMS (Maintenance Activities Module)

A maintenance activity management module for the Transportation Management System (TMS). This module enables users to add, update, and delete maintenance activities for vehicles, including details like maintenance type, date, description, and notes.

## Table of Contents

- [Project Description]
- [Database Schema Overview]
- [User Interface]
- [Core Functionalities]
- [Technology Stack]
- [Getting Started]
  - [Prerequisites]
  - [Installation]
  - [Running the Application]
- [API Endpoints]
- [Scalability and Extensibility]

## Project Description

This module is designed to manage vehicle maintenance activities within the TMS application. Users can perform CRUD operations on maintenance activities, helping keep track of all maintenance tasks associated with each vehicle in the system.

## Database Schema Overview

The database has two primary tables: **Vehicles** and **Maintenance Activities**.

### Vehicles Table
- `VehicleId` (Primary Key)
- `Name`

### Maintenance Activities Table
- `MaintenanceActivityId` (Primary Key)
- `VehicleId` (Foreign Key, linked to Vehicles table)
- `MaintenanceType`
- `Date`
- `Description`
- `Notes`

This structure allows each maintenance activity to be linked to a specific vehicle, capturing all relevant details.

## User Interface

The UI is built as a responsive web form using HTML, Bootstrap CSS, jQuery, and JavaScript. It includes input fields for adding, updating, and deleting maintenance activities, with validation for required fields like **Date**, **Vehicle Name**, and **Maintenance Type**.

## Core Functionalities

- **Add Maintenance Activity**: Adds maintenance activities for a vehicle through a form.
- **Update Maintenance Activity**: Edits existing maintenance records for a specific vehicle.
- **Delete Maintenance Activity**: Removes maintenance activity records from the system.

## Technology Stack

- **Backend**: ASP.NET Core MVC
- **Database**: Entity Framework (Code First)
- **Frontend**: HTML5, CSS3, jQuery, Bootstrap

## Getting Started

### Prerequisites

- .NET SDK 8.0
- SQL Server for local development
- A code editor, such as Visual Studio or Visual Studio Code

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/safiakhanofficial/tms-maintenance-module.git
   cd tms-maintenance-module

2. **Set up the Database**:
- The application automatically checks for and applies any pending migrations at startup, so there is no need to manually create the database or seed data.

3. **Configure Connection String**:
- In appsettings.json, update the connection string to point to your local database.

4. **Run the application and visit browser URL**:
  - https://localhost:7153
  - http://localhost:5208

### Endpoints
- Add Maintenance Activity: POST /Home/Add
- Update Maintenance Activity: POST /Home/Update
- Delete Maintenance Activity: DELETE /Home/Delete/{id}

These endpoints interact with maintenance activities, enabling CRUD operations.


