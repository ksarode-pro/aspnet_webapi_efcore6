#Stage 1
# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the project file into the container
# COPY ["aspnet_webapi_efcore6.csproj", "./"]
# Copy the rest of the application code into the container
COPY . .

# Restore the dependencies specified in the project file
RUN dotnet restore "./aspnet_webapi_efcore6.csproj"

# Publish the application in Release configuration to the /app/publish directory
RUN dotnet publish "aspnet_webapi_efcore6.csproj" -c Release -o /app/publish

#Stage 2
# Use the runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Set the working directory inside the container
WORKDIR /app

# Copy the published application from the build stage to the final stage
COPY --from=build /app/publish .

# Expose port 80 for HTTP traffic
EXPOSE 8080

# Expose port 443 for HTTPS traffic
EXPOSE 443

# Set the entry point for the container to run the application
ENTRYPOINT ["dotnet", "aspnet_webapi_efcore6.dll"]
