###############
# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj files and restore the dependencies

COPY ["src/Mc2.CrudTest.Domain/Mc2.CrudTest.Domain.csproj", "Mc2.CrudTest.Domain/"]
COPY ["src/Mc2.CrudTest.Infra/Mc2.CrudTest.Infra.csproj", "Mc2.CrudTest.Infra/"]
COPY ["src/Mc2.CrudTest.Application/Mc2.CrudTest.Application.csproj", "Mc2.CrudTest.Application/"]
COPY ["src/Mc2.CrudTest.WebApi/Mc2.CrudTest.WebApi.csproj", "Mc2.CrudTest.WebApi/"]

# Restore the dependencies
RUN dotnet restore "Mc2.CrudTest.WebApi/Mc2.CrudTest.WebApi.csproj"

# Copy the rest of the application files
COPY ./src/. .

# Build the application
RUN dotnet publish "Mc2.CrudTest.WebApi/Mc2.CrudTest.WebApi.csproj" -c Release -o /app/publish

## Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 5000

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Mc2.CrudTest.WebApi.dll"]