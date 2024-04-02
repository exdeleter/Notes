Для того, чтобы запустить это приложение, необходимо открыть Notes.sln и запустить проект в режиме Debug/Release, предварительно убедившись, что на компьютере установлен PostgreSQL и на appsettings.json/appsettings.Development.json указан верный логин и пароль от БД. 

Не до конца разобрался с тем, как локально поднять И БД, и микросервис, так, чтобы оно все работало. Была предпринята попытка настроить данный функционал, но не удалось, к сожалению.


Для запуска проекта необходимо выполнить следующие команды:
```cmd
dotnet build "src/Notes.Runner/Notes.Runner.csproj"
```

```cmd
dotnet run --project "src/Notes.Runner/Notes.Runner.csproj" --property:Configuration=Release
```