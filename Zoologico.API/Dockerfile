# --- Runtime Layer ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

# --- Build Layer ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos TODO el repo para que los proyectos se vean entre sí
COPY . .

# Restauramos usando la ruta correcta del .csproj
RUN dotnet restore "./Zoologicos.Modelos/Zoologico.API/Zoologico.API.csproj"

# Compilamos usando la ruta correcta también
RUN dotnet build "./Zoologicos.Modelos/Zoologico.API/Zoologico.API.csproj" -c Release -o /app/build

# --- Publish Layer ---
FROM build AS publish
RUN dotnet publish "./Zoologicos.Modelos/Zoologico.API/Zoologico.API.csproj" -c Release -o /app/publish

# --- Final Runtime ---
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zoologico.API.dll"]
