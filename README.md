# ASP.NET 8 - Authentication and Authorization in 7 steps.

# Introduction

In this tutorial, you will learn how to develop an API for user permission-based authentication and authorization. In addition, the _**Clean Architecture**_, **_Unit of Work_**, and **_Mediator_** patterns will be used.

---

# Patterns
### Mediator
This pattern aims to improve the way different parts of your application communicate with each other. Different parts of your application (components) don't talk directly to each other. Instead, they send requests to the mediator which is as a central point of communication in your application.


### Unit of Work
Is a design pattern used to manage a series of database operations as a single unit. The Unit of Work pattern groups database operations (Create, Delete, and Update) into a single transaction. This ensures that all operations are reflected in the database (commit). In case of an error, the pattern performs a rollback.

### Clean Architecture
Clean Architecture is a software design pattern that promotes maintainability, testability, and reusability by separating different concerns within the application into distinct layers. It's often visualized as an onion, with the core business logic (domain) at the center, surrounded by outward layers that handle progressively more external concerns.

**The layers in Clean Architecture:**
#### Domain
- Represents the core business logic of your application.
- Contains entities, value objects and interfaces.


#### Application 
- Implements the use cases of your application.
- Defines application services that manipulate domain entities.


#### Infrastructure 
- Contains concrete implementations for technical details.
- Provides interfaces for persistence (databases), external APIs, email services, etc.


#### Presentation 
- User access layer who can make requests to the application.
- Contains controllers, extensions and configurions.

---

# Tools
- C#
- .NET8
- Visual Studio 2022
- Docker
- Azure Data Studio

You can check the tutorial in this [link](https://dev.to/vinicius_estevam/aspnet-8-authentication-and-authorization-3426/)
