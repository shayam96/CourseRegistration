# Course Registration Application

## Overview

A simple ASP.NET Core Web API application implementing course enrollment, dropping, and FIFO waitlist promotion.

## Technologies

- C#
- .NET 8
- ASP.NET Core Web API
- xUnit
- Swagger

## Prerequisites

- Visual Studio 2022
- .NET 8 SDK

## How to Run

1. Open CourseRegistration.sln in Visual Studio.
2. Restore NuGet packages.
3. Set CourseRegistration as the startup project.
4. Build the solution.
5. Press F5 to run the application.
6. Open the Swagger URL displayed by Visual Studio.

## API Endpoints

### Enroll Student

POST /api/Enrollment/enroll/{studentId}

### Drop Student

DELETE /api/Enrollment/drop/{studentId}

### Check Enrollment Status

GET /api/Enrollment/status

## How to Run Automated Tests

1. Open Test Explorer in Visual Studio.
2. Click Run All.

Alternatively, execute:

dotnet test CourseRegistration.Tests/CourseRegistration.Tests.csproj

## Storage

The application currently uses in-memory collections. Data is reset when the application restarts.