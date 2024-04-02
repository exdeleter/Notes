using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Notes.Models.Dtos;

namespace Notes.Api.Validators;

/// <summary> Класс-расширение. </summary>
public static class ServiceCollectionExtension
{
    /// <summary> Добавление валидаторов.</summary>
    public static IServiceCollection AddValidators(this IServiceCollection services) => services
        .AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly);
}