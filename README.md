dotnet new sln -o Rest
dotnet new classlib -o Domain

dotnet sln add $(ls -r **/*.csproj)


dotnet add Api/ reference Contracts/ Application/
dotnet add Infrastructure/ reference Application/
dotnet add Application/ reference Domain/
dotnet add Api/ reference Infrastructure/

dotnet build
dotnet run --project Api/

dotnet new gitignore

dotnet-ef --startup-project Api/ migrations add NewMigration --project Infrastructure/
dotnet-ef --startup-project Api/ migrations remove  --project Infrastructure/
dotnet-ef --startup-project Api/ database update --project Infrastructure/