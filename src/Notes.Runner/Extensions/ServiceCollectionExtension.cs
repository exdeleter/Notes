using Asp.Versioning;
using Notes.Api.Validators;
using Notes.Infrastructure.Extension;

namespace Notes.Extensions;

/// <summary> Класс-расширение <see cref="IServiceCollection"/>. </summary>
public static class ServiceCollectionExtension
{
    /// <summary> Дополнительная конфигурация. </summary>
    public static IServiceCollection AdditionalConfiguration(this IServiceCollection services)
    {
        services.ConfigureInfrastructure();
        services.ConfigureSwagger();
        services.AddValidators();

        return services;
    }

    /// <summary> Сконфигурировать UI swagger.</summary>
    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}