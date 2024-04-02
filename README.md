Если есть возможность запустить приложение через IDE, то для запуска приложения необходимо открыть Notes.sln и запустить в режиме Debug/Release, предварительно убедившись, что на компьютере установлен PostgreSQL и в appsettings.json/appsettings.Development.json указан верный логин и пароль от БД. 

Не до конца разобрался с тем, как локально поднять И БД, и микросервис, так, чтобы оно все работало. Была предпринята попытка настроить данный функционал, но не удалось до конца разобраться с поднятием отдельно postgtres, к сожалению.

Для запуска проекта из командной строки необходимо открыть cmd в папке проекта и выполнить следующие команды:
```cmd
dotnet build "src/Notes.Runner/Notes.Runner.csproj"
```

```cmd
dotnet run --project "src/Notes.Runner/Notes.Runner.csproj" --property:Configuration=Release
```
