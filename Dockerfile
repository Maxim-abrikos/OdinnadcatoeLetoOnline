# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./
RUN dotnet publish "OdinnadcatoeLetoOnline/OdinnadcatoeLetoOnline.csproj" -c Release -o out

# Этап запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "OdinnadcatoeLetoOnline.dll"]