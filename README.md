# Assignment 2 — Car Rental Management System

## Project Description

This project is a console-based Car Rental Management System developed in Python and C#.

The assignment demonstrates Object-Oriented Programming (OOP) concepts, including classes, objects, constructors, properties, methods, encapsulation, and relationships between objects.

## Classes Implemented

**1. Car**
- Stores vehicle information.
- Manages vehicle availability.
- Displays car details and daily rental rates.

**2. Customer**
- Stores customer identification and contact details.
- Allows registration of customers.

**3. Rental**
- Connects customers to vehicles.
- Calculates rental costs.
- Handles vehicle rentals and returns.
- Maintains rental status.

## System Features

- View available and rented vehicles.
- Register customers.
- Rent vehicles for a selected number of days.
- Calculate rental costs automatically.
- Prevent duplicate rentals of unavailable vehicles.
- Return vehicles.
- View rental records.
- Validate basic user input.

## Technologies Used

- Python 3.11
- C# / .NET 9
- Visual Studio Code
- Git and GitHub

## Running the Python Application

From the project root:

`python python/main.py`

## Running the C# Application

From the project root:

`dotnet run --project csharp/CarRental.csproj`

## Example Rental

- Customer: John Doe
- Vehicle: Toyota Corolla
- Daily rental rate: 150 PLN
- Rental duration: 3 days
- Total rental cost: 450 PLN

## Object-Oriented Programming Concepts

The project demonstrates how separate classes interact within a practical application. Rental objects reference customer and car objects, allowing the system to manage bookings and vehicle availability.

## Author

Gerald Musiyazwiriyo

## Assignment

Assignment 2: Creating Classes and Objects — Car Rental Service