# Inventory System API

This is the web API and associated testing and infrastructure for the SRO inventory system.

More to follow soon.

## Setup

```sh
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef database update --project src/RoboticsOutreach.Inventory.Infrastructure
```

## Running

```sh
dotnet run
```
Then go to http://localhost:5097/swagger/index.html

## Subprojects

**`RoboticsOutreach.Inventory.Api`** - Web API (the public-facing interface)

**`RoboticsOutreach.Inventory.Application`** - Dunno

**`RoboticsOutreach.Inventory.Domain`** - Models of inventory data

**`RoboticsOutreach.Inventory.Infrastructure`** - Database management + internals
