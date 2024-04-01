## Fluent Validation in Asp.Net API

FluentValidation is a popular validation library for .NET applications. It provides a fluent and expressive syntax for defining validation rules for our models. With FluentValidation, we can easily validate user input and ensure data integrity, reducing the chance of errors and improving the overall quality of our application.
It offers a wide range of validaton rules and features, including-
- Customizable Validation Rules
- Property-Level and Cross-Property Validation
- Error Messages and Localization
- Rule sets - group validation rules together
- Asynchronous Validation
- Custom Error Codes and Severity Level
- Testing Support and more
It integrates seamlessly with ASP.NET core, making it a versatile choice for implementing robust and maintainable validation logic in our .NET projects.




1. Create a folder for the project and get into the directory
    ```
    mkdir FluentValidationAPI
    cd FluentValidationAPI
    ```
2. Create a solution named ***FluentValidationAPI*** 
    ```
    dotnet new  sln -n FluentValidationAPI
    ```
3. Create a project into the folder
    ```
    dotnet new webapi -f net6.0 -n FluentValidationAPI
    ```
4. Add the project into the solution
    ```
    dotnet sln add FluentValidationAPI/FluentValidationAPI.csproj
    ```
5. Open the solution with visual studio code
    ```
    code .
    ```
6. Add a gitignore file into the solution
    ```
    dotnet new gitignore
    ```
7. Add a README.md file into the solution
    ```
    touch README.md
    ```
8. Install the following packages
    ```
    dotnet add package FluentValidation -v 11.9.0  
    dotnet add package FluentValidation.AspNetCore -v 11.3.0  
    dotnet add package FluentValidation.DependencyInjectionExtensions -v 11.9.0
    ```
9. Inject FluentValidationAutoValidation into services in program file
    ```
    builder.Services.AddFluentValidationAutoValidation();
    ```
10. Create a folder named **Models** and  a model class named **User**
    ```
    mkdir Models
    cd Models
    dotnet new class -n User
    ```
    ```
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    ```
11. Now create a validator class named **UserValidator**
    ```
    dotnet new class -n UserValidator
    ```
    ```
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(user => user.Age).InclusiveBetween(18, 99).WithMessage("Age must be between 18 and 99.");
        }
    }
    ```
12. Register the validator into program file
    ```
    builder.Services.AddScoped<IValidator<User>, UserValidator>();
    ```
13. Now create a new POST method in the **WeatherForecastController**
    ```
    // Automatic validation
    [HttpPost]
    public IActionResult Create(User model)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

        // Continue with user creation process

        return StatusCode(StatusCodes.Status201Created, "User created successfully!");
    }
    ```
14. We have the option to specifically designate the class or model for which we want to create the validator. In this scenario, **Validate** method would provide **ValidationResult** object with two key attributes. The first is **IsValid**, a boolean indicating the success or failure of the validation process. The second attribute is **Errors**, which comprises a list of  **ValidationFailure** objects containing detailed information about any encountered errors. For that we will do the implementation such following-
    ```
    // Manual validation
    [HttpPut]
    public IActionResult Update(User user)
    {
        var validationResult = _userValidator.Validate(user);

        if (!validationResult.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors);
        }

        // Continue with user update process

        return StatusCode(StatusCodes.Status200OK, "User updated successfully!");
    }
    ```
    Now test the new PUT request and check if validators work or not.


#### Reference : https://dev.to/andytechdev/how-to-use-fluentvalidation-in-aspnet-core-net-6-2fnf