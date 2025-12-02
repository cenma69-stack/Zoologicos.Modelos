# --- Runtime Layer ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

# --- Build Layer ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos toda la solución (necesario para proyectos múltiples)
COPY . .

# Restauramos desde la carpeta donde está la API
RUN dotnet restore "./Zoologico.API/Zoologico.API.csproj"

# Build
RUN dotnet build "./Zoologico.API/Zoologico.API.csproj" -c Release -o /app/build

# --- Publish Layer ---
FROM build AS publish
RUN dotnet publish "./Zoologico.API/Zoologico.API.csproj" -c Release -o /app/publish

# --- Final Runtime ---
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zoologico.API.dll"]
