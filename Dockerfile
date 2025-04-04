# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Use the runtime image for execution
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose the required port
EXPOSE 8080

# Run the application
CMD ["dotnet", "SignalRChat.dll"]
