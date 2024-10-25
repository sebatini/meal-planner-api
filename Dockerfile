# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY MealPlannerApi.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build the application
RUN dotnet build -c Release -o out

# Publish the application
RUN dotnet publish -c Release -o out/publish

# Use the official ASP.NET Core runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out/publish .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "MealPlannerApi.dll"]
