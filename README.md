# Weather Forecast

## Description

Weather Forecast is a simple web application that provides current weather information and forecasts. This project is a .NET application that follows the principles of **Command Query Responsibility Segregation (CQRS)**, and employs the **Onion Architecture pattern**. 
It is designed to provide a scalable and modular solution. The project is written in **C#** with **.NET** and uses **Entity Framework Core** to manage the database. It embraces the **SOLID** principles to ensure a clean and maintainable codebase.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Contributing](#contributing)

## Installation

1. Clone the repository:

   ```
   git clone https://github.com/ecesari/weather-forecast.git

## Usage

You can either run the application on your local machine or use docker to run it. To run the Weather Forecast application using Docker Compose, follow these steps:

1. Build the Docker image:

   ```bash
   docker-compose build
2. Start the application:
   ```bash
   docker-compose up

3. Open your browser and go to http://localhost:8080/swagger for the list of endpoints.

## Features

- **Onion Architecture**: The project is structured following the Onion Architecture pattern, ensuring a clear separation of concerns with distinct layers for the core application logic, application services, and infrastructure.

- **CQRS (Command Query Responsibility Segregation)**: CQRS is implemented to separate the write (command) and read (query) sides of your application. This architecture enables efficient data retrieval and optimized command handling.

- **Entity Framework Core**: Entity Framework Core is used as the data access technology, providing a seamless and efficient way to interact with your database.

- **xUnit Testing**: The project utilizes xUnit as the testing framework to ensure code quality and reliability.

- **MediatR**: MediatR is integrated to handle requests and commands, promoting loose coupling and improving the organization of your application's business logic.

- **FluentValidation**: FluentValidation is employed for robust and expressive validation of input data.

- **Docker**: Docker is used to containerize the application, ensuring consistency across different environments.

- **AutoMapper**: AutoMapper is utilized for easy object-to-object mapping, simplifying the data transformation process.

- **Swagger**: Swagger is integrated for API documentation, allowing developers to explore and test the API endpoints easily.
  

## Contributing

1. Fork the project.
2. Create a new branch (git checkout -b feature/new-feature).
3. Make your changes.
4. Commit your changes (git commit -m 'Add new feature').
5. Push to the branch (git push origin feature/new-feature).
6. Open a pull request.
