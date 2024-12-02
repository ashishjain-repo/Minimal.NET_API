# What are Minimal APIs?
Minimal APIs are arcitected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimal files, features, and dependencies in ASP.NET Core.

# Model - View - Controller
- Split program logic into three (interconnected) elements.
- Widely adopted in web development frameworks:
    1. Ruby on Rails
    2. Spring
    3. Django
    4. ASP.NET Core MVC
- Model: Defined Data Structure; Update the View.
- View: Display of Data (UI); Send input from User to Controller.
- Controller: Map requests to action; Manipulates the Model.

# Minimal API
- Minimal APIs do not have a controller
- Do not support Model validation
- Do not support JSONPatch
- Do not support filters
- Do not support custom model binding

# Scaffold Minimal
To create a minimal api we are going to use the webapi template of ASP.NET Core Web Api, and we will be adding a flag to let the system know we are targeting to build a Minimal API. To do that we will use this command in the folder we are planning on creating a project: `dotnet new webapi -minimal`. Usually we will get a main file with some code written but to make that project empty we are going to keep only the following:-
```
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
```

# Package Dependencies
First dependeny we are going to install for our application will be `EntityFrameworkCore`, we can use the command `dotnet add package nameOfThePackage` to install the dependencies in our project. This is the command for Entity Framework Core, `dotnet add package Microsoft.EntityFrameworkCore` when this is installed it should be added into your .csproj file. We are also going to add `EntityFrameworkCore.Design`, this is the command: `dotnet add package Microsoft.EntityFrameworkCore.Design`. We are also going to use install `EntityFrameworkCore.SqlServer` because our primary DBMS is going to be Sql Server, the command is: `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`. The last package that we are going to install will be `AutoMapper`, this is not from Microsoft, so we are going to use this command: `dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection`.

# Initalizing User Secrets
We are going add the connection string to connect to our sql server, we are going to use `user-secrets` to save password and userid. To do that in the main directory we will run this command: `dotnet user-secrets init`. This will add a secret Id to our .csproj file.

# Model and DTO Creation
We are going to create a folder named `Models` and create a file command.cs where we are going to define our models. We are also going to put the attribute in our class properties which 
demonstrte the validation in Minimal APi because minimal api lacks in validation. We are going to use `Key` and `Required` which means Key is the Primary Key of the database table, and the Required is for that the property cannot be null. We are also going to use the validation attribute `MaxLength()` to make sure the we are following the key rules for the database as per the requirment.
Now we are going to create DTO's which are external representation of the Internal Model class. We are going to create three DTO's which will be for Reading the data or GET, Creating the data or POST, or Updating the data or PUT. Now we are going to create a  new folder in the main directory named `Dtos`.