# Command Dotnet

dotnet new sln --name AdminEyeMMO
dotnet new worker --name Orchestrator-AdminEyeMMO
dotnet sln add Orchestrator-AdminEyeMMO/Orchestrator-AdminEyeMMO.csproj
dotnet new webapi --use-controllers -o AdminEyeMMOAPI
dotnet sln add AdminEyeMMOAPI/AdminEyeMMOAPI.csproj
dotnet new classlib -o ApplicationMMO 
dotnet sln add ApplicationMMO/ApplicationMMO.csproj
dotnet sln add InfrastructureMMO/InfrastructureMMO.csproj
dotnet add ApplicationMMO/ApplicationMMO.csproj reference InfrastructureMMO/InfrastructureMMO.csproj
dotnet add AdminEyeMMOAPI/AdminEyeMMOAPI.csproj reference ApplicationMMO/ApplicationMMO.csproj

dotnet new classlib -o DomainMMO 
dotnet add AdminEyeMMOAPI/AdminEyeMMOAPI.csproj reference DomainMMO/DomainMMO.csproj
dotnet sln add DomainMMO/DomainMMO.csproj

# Command Git
touch .gitignore

# Command EF

dotnet ef migrations add InitialCreate
dotnet ef database update

# Packages

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools