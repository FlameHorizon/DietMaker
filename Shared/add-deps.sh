#!/usr/bin/env bash

dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.2
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.2
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0-preview.2.efcore.9.0.0

