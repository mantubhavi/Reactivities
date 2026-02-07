# API Name

.NET 10 Web API project.

## Requirements
- .NET SDK 10.0
- macOS / Linux / Windows

## Getting Started

### Restore packages
dotnet restore

## EF migration
dotnet ef migrations add InitialCreate -p Persistence -s API 
dotnet ef database update

