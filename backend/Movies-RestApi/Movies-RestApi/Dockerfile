FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Kopiujemy plik solution (np. MyApp.sln)
COPY *.sln ./

# Kopiujemy plik .csproj z backend/movies-rest-api do osobnego katalogu w obrazie
COPY backend/movies-rest-api/*.csproj ./backend/movies-rest-api/

# Przygotowanie zależności
RUN dotnet restore

# Kopiujemy cały kod źródłowy
COPY backend/movies-rest-api/. ./backend/movies-rest-api/

# Przechodzimy do katalogu projektu
WORKDIR /app/backend/movies-rest-api

# Budujemy aplikację w trybie Release
RUN dotnet publish -c Release -o out

# Tworzymy obraz runtime (lżejszy, bez SDK)
FROM mcr.microsoft.com/dotnet/  aspnet:8.0
WORKDIR /app

# Kopiujemy wynik publikacji z etapu build
COPY --from=build /app/backend/movies-rest-api/out .

# Uruchamiamy aplikację
ENTRYPOINT ["dotnet", "movies-rest-api.dll"]
