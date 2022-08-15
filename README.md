# Welcome to the test-case for Farmasi!

This app contains three main parts;
- Backend .NET Core API Project is located in *Farmasi.Basket.Api* folder.
- Redis Cache for cart system needs to be configured in *appsettings.json* (I used a local one)
- Database MongoDB is located on atlas cloud service of mongoDB. (connection string is located in *appsettings.json*)

# Requirements
  - dotnet runtime for API project
  - redis db for basket cache
  - an internet connection for db

- clone the project

# To run the Backend .NET Core API Project,
  
  ## If you have visual studio  
  - find and open the solution(.sln file) in *Farmasi.Basket.Api* folder
  - hit f5 to run the project

  ## If you want to use terminal
  - open a terminal
  - cd *Farmasi.Basket.Api*
  - dotnet publish
  - dotnet .\Farmasi.Basket.Api\bin\Debug\net6.0\publish\Farmasi.Basket.Api.dll

