# Use the official .NET 8 runtime as the base image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

# Use the .NET 8 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ChallengeB_App.csproj ChallengeB_App/
WORKDIR /src/ChallengeB_App
RUN dotnet restore

# Copy the full source code and build the app
COPY . .
RUN dotnet build -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Ensure input folder exists & copy input file
RUN mkdir -p /app/input
COPY random_object.txt /app/input/random_object.txt

RUN mkdir -p /app/output

# Set up the entrypoint
ENTRYPOINT ["dotnet", "ChallengeB_App.dll"]
