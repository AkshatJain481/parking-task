# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the csproj file and restore any dependencies
COPY ["ParkingLotSystemBackend.csproj", "parking-task/"]
RUN dotnet restore "parking-task/ParkingLotSystemBackend.csproj"

# Copy the rest of the application code and build it
COPY . .
WORKDIR "/src/parking-task"
RUN dotnet build "ParkingLotSystemBackend.csproj" -c Release -o /app/build

# Publish the application to a folder in the container
FROM build AS publish
RUN dotnet publish "ParkingLotSystemBackend.csproj" -c Release -o /app/publish

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParkingLotSystemBackend.dll"]
