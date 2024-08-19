
# N Layer Core

N Layer Core is a robust .NET package designed to simplify and enhance the development of multi-layered applications. It offers a comprehensive set of tools and patterns, including the Repository Design Pattern, Unit of Work, JWT-based authentication, hashing and salting, paging, Redis caching, and the Result Pattern. This package is aimed at developers looking for a standardized, modular approach to building scalable and maintainable applications.

## Features

- **Repository Design Pattern**: Simplifies data access by encapsulating the logic for retrieving, saving, and managing data in a consistent way.
- **Unit of Work Design Pattern**: Ensures that a series of operations are treated as a single transaction, providing a reliable way to manage data consistency.
- **Hashing and Salting**: Provides secure methods for storing sensitive data, like passwords, by hashing and salting.
- **JWT-based Authentication**: Implements secure token-based authentication using JSON Web Tokens (JWT).
- **Paging**: Built-in support for paginating results from your data sources.
- **Result Pattern**: Standardizes the way results, including errors, are handled and returned from methods.
- **Redis Caching**: Leverages Redis for distributed caching to improve performance and scalability.

## Installation

To install the N Layer Core package, run the following command in your NuGet Package Manager Console:

```shell
Install-Package NLayerCore
```

# Defining Entity
```csharp
using NLayerCore.Repositories;

namespace Project.Entities.Concrete;

public class Customer : Entity<int>
{
    public string Name { get; set; }
}
```

# Defining Repositories
## Defining Interface
```csharp
using Project.Entities.Concrete;
using NLayerCore.Repositories;

namespace InvoiceCustomer.DataAccess.Abstract;

public interface ICustomerRepository : IAsyncRepository<Customer,int>, IRepository<Customer,int>
{

}

```

## Defining Class
```csharp
using Project.DataAccess.Abstract;
using Project.DataAccess.Contexts;
using Project.Entities.Concrete;
using NLayerCore.Repositories;

namespace Project.DataAccess.Concrete;

public class CustomerRepository : EfRepositoryBase<Customer, int, BaseContext>, ICustomerRepository
{
    public CustomerRepository(BaseContext context) : base(context)
    {

    }
}
```
