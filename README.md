## Fluent Validation in Asp.Net API




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
8. 