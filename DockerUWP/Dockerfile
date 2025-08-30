# Use the .NET SDK image to build and run in a single stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory
WORKDIR /app

# Build argument
ARG BUILD_CONFIGURATION=Release

# Copy csproj and restore dependencies
COPY ["DockerUWP/DockerUWP.csproj", "DockerUWP/"]
RUN dotnet restore "./DockerUWP/DockerUWP.csproj"

# Copy all source code
COPY . .

# Build and publish the project
WORKDIR "/app/DockerUWP"
RUN dotnet publish "./DockerUWP.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Set the working directory to published output
WORKDIR /app/publish

# Expose ports
EXPOSE 8080
EXPOSE 8081

# Set entry point
ENTRYPOINT ["dotnet", "DockerUWP.dll"]