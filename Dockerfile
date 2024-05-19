# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy the solution file and the project file
COPY jobs/jobs.sln ./
COPY jobs/jobs.csproj ./jobs/

# Restore dependencies
RUN dotnet restore jobs/jobs.sln

# Copy the rest of the application and build
COPY jobs/ ./jobs/
RUN dotnet publish jobs/jobs.csproj -c Release -o out

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .

# Expose the port
EXPOSE 8080

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "jobs.dll"]
