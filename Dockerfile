# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# Copy solution and project files for restore
COPY CMS.slnx .
COPY Api/Api.csproj Api/
COPY Application/Application.csproj Application/
COPY Domain/Domain.csproj Domain/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY CMS/CMS.csproj CMS/

# Restore dependencies
RUN dotnet restore Api/Api.csproj

# Copy everything else and build
COPY . .
WORKDIR /source/Api
RUN dotnet publish -c Release -o /app

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Expose port
EXPOSE 8080

# Entry point
ENTRYPOINT ["dotnet", "Api.dll"]
