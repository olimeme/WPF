FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY EarthquakeAPI/EarthquakeAPI.csproj EarthquakeAPI/
RUN dotnet restore EarthquakeAPI/EarthquakeAPI.csproj
COPY . .
WORKDIR /src/EarthquakeAPI
RUN dotnet build EarthquakeAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EarthquakeAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EarthquakeAPI.dll"]
