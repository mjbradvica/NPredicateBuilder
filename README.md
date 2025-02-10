# NPredicateBuilder

Simple, testable, LINQ queries for dotnet.

![TempIcon](https://i.imgur.com/plmmAcK.png)

![build-status](https://github.com/mjbradvica/NPredicateBuilder/workflows/main/badge.svg) ![downloads](https://img.shields.io/nuget/dt/NPredicateBuilder) ![downloads](https://img.shields.io/nuget/v/NPredicateBuilder) ![activity](https://img.shields.io/github/last-commit/mjbradvica/NPredicateBuilder/master)

## Overview

NPredicateBuilder is a way to build LINQ queries and orders with the following:

- :microscope: Small API (2 methods and 2 base classes)
- :straight_ruler: Learn in 5 minutes
- :key: Easily integrate into LINQ
- :heavy_check_mark: Write testable queries in seconds
- :recycle: Reuse your queries and orders

## Table of Contents

- [NPredicateBuilder](#npredicatebuilder)
  - [Overview](#overview)
  - [Table of Contents](#table-of-contents)
  - [Dependencies](#dependencies)
  - [Installation](#installation)
  - [Quick Start](#quick-start)
    - [Queries](#queries)
    - [Orders](#orders)
    - [Compound Boolean Logic](#compound-boolean-logic)
    - [Testing](#testing)
  - [Documentation](#documentation)
  - [Samples](#samples)
  - [FAQ](#faq)
    - [What is NPredicateBuilder?](#what-is-npredicatebuilder)
    - [Do I need NPredicateBuilder?](#do-i-need-npredicatebuilder)
    - [What's the difference between the base library and the EF version?](#whats-the-difference-between-the-base-library-and-the-ef-version)
    - [How is performance?](#how-is-performance)
    - [How does NPredicateBuilder work with other LINQ statements?](#how-does-npredicatebuilder-work-with-other-linq-statements)

## Dependencies

- Base Library - None
- EF Library - [LinqKit.Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/LinqKit.Microsoft.EntityFrameworkCore)

NPredicateBuilder uses LinqKit to expand queries into a properly formed IQueryable.

## Installation

The best way is to use [NuGet](https://www.nuget.org/packages/NPredicateBuilder/) for installation.

In your domain layer:

```bash
Install-Package NPredicateBuilder
```

If you are doing LINQ to Entities, install the following in your data access layer.

```bash
Install-Package NPredicateBuilder.EF
```

## Quick Start

### Queries

For any entity that you wish to query against, create a query class that derives from the BaseQuery class of T, where T is your entity type.

```csharp
public class PeopleQuery : BaseQuery<People>
{
}
```

Create queries with the "Add" or "Or" logic by creating methods and returning the query object.

```csharp
public class PeopleQuery : BaseQuery<People>
{
    public PeopleQuery AndNameIs(string name)
    {
        AddAndCriteria(x => x.Name == name);

        return this;
    }

    public PeopleQuery OrAgeIsOver(int age)
    {
        AddOrCriteria(x => x.Age > age);

        return this;
    }
}
```

Start a query by creating a query class and chaining methods to produce the query you desire.

> If using LINQ-to-Entities, your final query must be SQL compatible.

Then, create a complex query by chaining them together.

```csharp
var peopleQuery = new PeopleQuery()
    .AndNameIs("brad")
    .OrAgeIsOver(10);
```

Pass your queries and orders to the designated extension method.

```csharp
var result = ApplicationContext.People
            .NPredicateBuilderEFWhere(peopleQuery);
```

If using plain LINQ-to-Objects, there is the same extension method for the IEnumerable interface.

```csharp
var result = people.NPredicateBuilderWhere(peopleQuery);
```

Because it is just an extension method, the NPredicateBuilder method behaves like any other LINQ to Objects or LINQ to Entities query.

```csharp
var result = ApplicationContext.People
            .NPredicateBuilderEFWhere(peopleQuery)
            .Skip(10)
            .Take(15)
            .Select(x => new { x.Name, x.Age })
            .ToList();
```

NPredicateBuilder can easily be added to any existing or new codebase, no matter what size!

### Orders

Orders follow the same pattern as queries. Create an Order class for an entity, and start adding methods.

```csharp
public class PeopleOrders : BaseOrder<People>
{
    public PeopleOrders ByAge()
    {
        OrderBy(x => x.Age);

        return this;
    }

    public PeopleOrders ThenByNameDescending()
    {
        ThenByDescending(x => x.Name);

        return this;
    }
}
```

Plug your orders into any query you want the same way by utilizing either extension method.

```csharp
var myOrder = new PeopleOrders()
                .ByAge()
                .ThenByNameDescending();

var ordered = people
                .Skip(10)
                .Take(30)
                .NPredicateBuilderOrder(myOrder)
                .ToList();
```

### Compound Boolean Logic

When you need to combine both logical "And" plus "Or" statements into a query, then you can use the built-in method, which allows you to combine multiple queries.

```csharp
var filtered = new PeopleQuery()
                .AndAgeIsOver(10)
                .AndNameIs("mike")
                .Or(new PeopleQuery()
                    .AndAgeIsUnder(6)
                    .AndNameIs("jessica"));
```

With a logical "Or" between both statements, your query will return any "Mike" over the age of 10 AND any "Jessica" under 6.

Without the "Or" separator, this query would return nothing, since it is impossible for all four statements to be evaluated as true for any person.

> The samples provide more examples on how to structure more complex compound queries.

### Testing

Unit tests are easy to write for queries and orders.

```csharp
[TestMethod]
public void Where_Queryable_FiltersCorrectly()
{
    _customers = new List<Customer>
    {
        TestHelper.Billy(),
        TestHelper.Bobby(),
    };

    var query = new CustomerTestQuery().AndNameIsBobby();

    var result = _customers.AsQueryable().NPredicateBuilderEFWhere(query);

    Assert.AreEqual("Bobby", result.Single().Name);
}

[TestMethod]
public void OrderBy_IEnumerable_OrdersCorrectly()
{
    _customers = new List<Customer>
    {
        TestHelper.Bobby(),
        TestHelper.Billy(),
        TestHelper.Bobby(),
    };

    var order = new CustomerTestOrder().ByName();

    var result = _customers.NPredicateBuilderOrder(order);

    Assert.AreEqual("Billy", result.First().Name);
}
```

## Documentation

More documentation can be [viewed in the wiki](https://github.com/n-predicate-builder/NPredicateBuilder/wiki).

It's only a five-minute read!

## Samples

Samples are available [here](https://github.com/mjbradvica/NPredicateBuilder/tree/master/samples/NPredicateBuilder.Samples) if more clarity is required.

## FAQ

### What is NPredicateBuilder?

NPredicateBuilder is a way to write LINQ queries and orders that can be tested individually and then reused multiple times to cut down on duplication.

### Do I need NPredicateBuilder?

If your application is simple and has a minimum amount of simple queries-you may not need it.

NPredicateBuilder was created for situations when you find yourself writing the same "Where" or "Order" statement multiple times, or even when you have very complex queries that require testing.

### What's the difference between the base library and the EF version?

If you are doing LINQ-to-Objects you only need the base library.

If you are using EntityFramework you need the EF library for NPredicateBuilder to work properly.

### How is performance?

Your experience may vary depending on the complexity of your queries.

Generally, NPredicateBuilder will be a little slower due to each query needing to be expanded. But we are talking milliseconds. Unless your performance requirements are extreme, the difference is not noticeable.

### How does NPredicateBuilder work with other LINQ statements?

It works like any other LINQ statement because it's an extension method for either the IEnumerable or IQueryable interfaces.
