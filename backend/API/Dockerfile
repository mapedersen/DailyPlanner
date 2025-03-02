# Use the .NET SDK image for development with hot reload
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base
WORKDIR /app

# Copy the solution and project files first (to leverage Docker caching)
COPY *.sln ./
COPY API/*.csproj API/

# Restore dependencies
RUN dotnet restore API/DailyPlanner.API.csproj

# Copy the remaining files and set up the application
COPY API/ API/
WORKDIR /app/API

# Expose ports for HTTP
EXPOSE 5267

# Run the application with dotnet watch (this will restart the app on code changes)
CMD ["dotnet", "watch", "run"]
