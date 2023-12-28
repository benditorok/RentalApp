#Build from this project's folder using: docker build .. -t rentalapp -f Dockerfile
#When running a container: -p 8080:8080 -e NPGSQL_RENTAL="Host=<ip>; Port=5432; Database=<db>; Username=postgres; Password=<pwd>"

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
COPY ["RentalApp.Endpoint/RentalApp.Endpoint.csproj", "RentalApp.Endpoint/"]
RUN dotnet restore "./RentalApp.Endpoint/./RentalApp.Endpoint.csproj"
COPY . .
WORKDIR "./RentalApp.Endpoint"
RUN dotnet build "./RentalApp.Endpoint.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RentalApp.Endpoint.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentalApp.Endpoint.dll"]