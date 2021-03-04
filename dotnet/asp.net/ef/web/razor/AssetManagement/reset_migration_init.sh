#!/bin/bash

# Drops current SQLite database, create new migration and launch the server

rm -rf ./bin/
rm -rf ./obj/

rm -rf Migrations # dotnet ef migrations remove
dotnet ef database drop --force
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
