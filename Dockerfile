# Установка базового образа
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

USER $APP_UID
# Установка рабочей директории
WORKDIR /app
# Открытие портов
EXPOSE 8080
EXPOSE 8081

# Сборка приложения
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# Установка переменной конфигурации сборки
ARG BUILD_CONFIGURATION=Release
# Установка рабочей директории с исходным кодом
WORKDIR /src
# Копирование файла проекта внутрь контейнера
COPY ["src/", "./"]
# Восстановление зависимостей
RUN dotnet restore "Notes.Runner/Notes.Runner.csproj"
# Копирование остальных файлов проекта
COPY . .
# Установка рабочей директории внутри проекта
WORKDIR "/src/Notes.Runner"
# Сборка проекта
RUN dotnet build "Notes.Runner.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Публикация приложения
FROM build AS publish
# Установка переменной конфигурации сборки
ARG BUILD_CONFIGURATION=Release
# Публикация приложения
RUN dotnet publish "Notes.Runner.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM postgres:latest AS postgres
# Настройка переменных среды для PostgreSQL
ENV POSTGRES_DB=notes_database
ENV POSTGRES_USER=notes_user
ENV POSTGRES_PASSWORD=notes_password

# Конечный образ
FROM base AS final
# Установка рабочей директории
WORKDIR /app
COPY --from=postgres / /
# Копирование собранного приложения из предыдущего этапа
COPY --from=publish /app/publish .
# Запуск приложения
ENTRYPOINT ["dotnet", "Notes.Runner.dll"]
