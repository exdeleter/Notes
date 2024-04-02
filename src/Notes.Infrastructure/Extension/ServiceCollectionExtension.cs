using Microsoft.Extensions.DependencyInjection;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Repositories;
using Notes.Models.Dtos;
using Notes.Models.Entities;

namespace Notes.Infrastructure.Extension;

/// <summary> Класс-расширение <see cref="IServiceCollection"/>. </summary>
public static class ServiceCollectionExtension
{
    /// <summary> Сконфигурировать медиатор. </summary>
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));
        
        services.AddScoped<IRepository<Note, NoteDto>, NoteRepository>();
        services.AddScoped<IRepository<Reminder, ReminderDto>, ReminderRepository>();
        services.AddScoped<IRepository<Tag, TagDto>, TagRepository>();

        return services;
    }
}