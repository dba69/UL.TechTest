# UL.TechTest
Technical test solution to allow users to calculate Factorials and generate FizzBuzz output.

The solution utilises the following patterns and packages:
- Service Factory Pattern - Permits services to be created via a DI service factory, allowing for clean separation of business service logic for improved reuse and ease of testing.
- Fluent Result - A lightweight Result object implementation for .NET.
- Fluent Validation - A validation library for .NET that uses a fluent interface to construct strongly-typed validation rules.

The solution consist of the following projects:

## UL.TechTest.API
Web API project providing the following methods:
  - GetFactorial: HttpGet method with required integer input (min:1, max:10000), returns the factorial result as a numeric string.
  - GetFizzBuzz: HttpGet method returns 100 lines to specified FizzBuzz output.

The API project provides a Swagger UI to visualise and run the aforementioned methods.

Set this project as Startup to run the application.

## UL.TechTest.Services
Class library providing access to business logic services:
  - FactorialService:
    - Input: integer value up from 1 to 10000.
    - Validation: Validate that input is greater than 0 and less than or equal to 10000.
    - Calculates the factorial using .NET BigInteger structure.
  - FizzBuzzService:
    - Calculate FizzBuzz from 1 to 100 as detailed in test requirements.

## UL.TechTest.Test
Unit tests covering basic use cases.
