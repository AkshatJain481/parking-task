# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file and restore any dependencies
COPY ParkingLotSystemBackend.csproj ./
RUN dotnet restore ParkingLotSystemBackend.csproj

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet build ParkingLotSystemBackend.csproj -c Release -o /app/build

# Publish the application to a folder in the container
RUN dotnet publish ParkingLotSystemBackend.csproj -c Release -o /app/publish

# Use the official ASP.NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 80

# Define the entry point for the application
ENTRYPOINT ["dotnet", "ParkingLotSystemBackend.dll"]
