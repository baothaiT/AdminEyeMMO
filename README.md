# Command Dotnet

dotnet new sln --name AdminEyeMMO

dotnet new worker --name Orchestrator-AdminEyeMMO

dotnet sln add Orchestrator-AdminEyeMMO/Orchestrator-AdminEyeMMO.csproj

dotnet new webapi --use-controllers -o AdminEyeMMOAPI

dotnet sln add AdminEyeMMOAPI/AdminEyeMMOAPI.csproj

dotnet new classlib -o ApplicationMMO 

dotnet sln add ApplicationMMO/ApplicationMMO.csproj

dotnet sln add InfrastructureMMO/InfrastructureMMO.csproj


# Command Git