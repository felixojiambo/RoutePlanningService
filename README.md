# Route Planning & Trip History Service

## Overview

The **Route Planning & Trip History Service** optimizes routes for electric vehicles (EVs) and manages historical trip data. It integrates with third-party APIs (like Google Maps) for route optimization and with a **Machine Learning Service** for energy consumption predictions. It also provides trip analytics and stores historical trip information for users.

## Features

- **Route Planning:** Optimize routes based on distance, traffic, and energy consumption.
- **Trip History:** Store and retrieve past trips for users.
- **Trip Analytics:** Analyze historical trip data, including energy consumption and route efficiency.
- **External API Integration:** Uses Google Maps API for route data and communicates with the **Machine Learning Service** for energy predictions.

## Technologies

- **ASP.NET Core Web API** for the service.
- **SQL Server** for storing trip data and history.
- **Docker** for containerization.
- **Google Maps API** for route planning.
- **Machine Learning Service** for energy consumption prediction.

---

## Table of Contents
1. [System Requirements](#system-requirements)
2. [Installation and Setup](#installation-and-setup)
3. [API Endpoints](#api-endpoints)
4. [Environment Variables](#environment-variables)
5. [Running the Service](#running-the-service)
6. [Testing](#testing)
7. [Troubleshooting](#troubleshooting)

---

## System Requirements

Before setting up the service, ensure you have the following:

- **.NET SDK 6.0+**
- **Docker** (optional for containerization)
- **SQL Server** (local or cloud instance)
- **Google Maps API Key**
- **Python Environment** (for Machine Learning Service integration)

---

## Installation and Setup

### Step 1: Clone the Repository

```bash
git clone https://github.com/felixojiambo/RoutePlanningService/.git
cd RoutePlanningService
```

### Step 2: Install Dependencies

Install the necessary .NET dependencies:

```bash
dotnet restore
```

### Step 3: Set Up Environment Variables

Create a `.env` file at the root of the project with the following environment variables:

```bash
# SQL Server connection string
SQLSERVER_CONNECTION_STRING=Server=localhost;Database=RoutePlanningDB;User Id=TEST;Password=testpassword;

# Google Maps API Key
GOOGLE_MAPS_API_KEY=dnsakjhef1234rthrgfed

# Machine Learning Service URL
ML_SERVICE_URL=http://ml-service:5000/predict-energy
```

### Step 4: Set Up SQL Server Database

1. Install SQL Server if not already installed (or use a cloud instance like Azure SQL).
2. Create a new database called `RoutePlanningDB`.
3. Update your `.env` file with your SQL Server credentials.

You can run migrations using Entity Framework to set up your database schema:

```bash
dotnet ef database update
```

---

## API Endpoints

### 1. **Route Planning**

- **Endpoint:** `POST /routes/plan`
- **Description:** Optimize a route for an EV based on start and end points, considering traffic and energy consumption.
- **Request Body:**
  ```json
  {
    "start_location": "start_location_coordinates",
    "end_location": "end_location_coordinates",
    "vehicle_id": "EV12345"
  }
  ```
- **Response:**
  ```json
  {
    "route": [
      {"lat": "xxx", "long": "xxx"},
      ...
    ],
    "estimated_energy": 45.5
  }
  ```

### 2. **Trip History**

- **Endpoint:** `GET /routes/history`
- **Description:** Retrieve historical trips for a given user.
- **Query Params:**
  - `user_id`: ID of the user.
- **Response:**
  ```json
  [
    {
      "trip_id": "trip123",
      "start_location": "...",
      "end_location": "...",
      "date": "2024-01-01",
      "energy_used": 50.2
    },
    ...
  ]
  ```

### 3. **Trip Analytics**

- **Endpoint:** `GET /routes/analytics`
- **Description:** Get aggregated trip data, including total trips, average energy consumption, and other statistics.
- **Query Params:**
  - `user_id`: ID of the user.
- **Response:**
  ```json
  {
    "total_trips": 100,
    "average_energy": 48.3,
    "total_distance": 1200
  }
  ```

---

## Environment Variables

- `SQLSERVER_CONNECTION_STRING`: Connection string to SQL Server.
- `GOOGLE_MAPS_API_KEY`: API key for Google Maps.
- `ML_SERVICE_URL`: URL for the Machine Learning Service to predict energy consumption.

---

## Running the Service

### Running Locally

1. Ensure SQL Server is running and accessible.
2. Run migrations to set up the database:

```bash
dotnet ef database update
```

3. Start the service:

```bash
dotnet run
```

### Running with Docker

1. Build the Docker image:

```bash
docker build -t route-planning-service .
```

2. Run the service in a Docker container:

```bash
docker run -d -p 5000:80 --env-file .env route-planning-service
```

---

## Testing

Unit tests are provided to validate the service functionality.

### Run Unit Tests

```bash
dotnet test
```

---

## Troubleshooting

- **SQL Server Connection Issues:**
  - Ensure that SQL Server is running and accessible. Verify your connection string in the `.env` file.
  - If you're running SQL Server in a Docker container, make sure ports are exposed correctly.

- **Google Maps API Errors:**
  - Ensure your Google Maps API Key is valid and that billing is enabled in your Google Cloud Console.

- **Machine Learning Service Issues:**
  - Ensure the **Machine Learning Service** is running and accessible via the correct URL specified in the `.env` file.

---

## License

This project is licensed under the MIT License.
