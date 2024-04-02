using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.Database.Extensions;

/// <summary> Класс, расширяющий <see cref="WebApplication"/>. </summary>
public static partial class ServiceCollectionExtension
{
    /// <summary> Выполнение непроведенных миграций. </summary>
    public static async void ApplyMigrate(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<NotesContext>();
        await db.Database.MigrateAsync();
    }
}