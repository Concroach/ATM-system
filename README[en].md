# ATM System

## Description
The ATM system is implemented using **ASP.NET Core**, **Entity Framework**, and **PostgreSQL** database.

## Features
- Account creation
- View account balance
- Withdraw funds
- Deposit funds
- View transaction history

## Architecture
Hexagonal architecture is used:
- **Application** – Async/Sync services (business logic), ports, entities
- **Infrastructure** – Database, repositories, migrations
- **Presentation** – Web API and console representations

## Technologies
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **PostgreSQL**
- **xUnit, Moq**

## Project Setup
1. Install dependencies:
   ```sh
   dotnet restore
   ```
2. Apply database migrations:
   ```sh
   dotnet ef database update
   ```
3. Run the application:
   ```sh
   dotnet run
   ```

## Testing
Unit tests are written to verify business logic using mocks.

Run tests:
```sh
dotnet test
```
