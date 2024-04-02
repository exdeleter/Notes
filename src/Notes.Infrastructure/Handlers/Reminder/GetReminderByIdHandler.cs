using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Queries.Reminder;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Reminder;

/// <summary> Обработчик получения <see cref="Reminder"/> по идентификатору.</summary>
public class GetReminderByIdHandler : IRequestHandler<GetReminderByIdQuery, ReminderDto?>
{
    private readonly IRepository<Models.Entities.Reminder, ReminderDto> _repository;
    private readonly ILogger<GetReminderByIdQuery> _logger;

    public GetReminderByIdHandler(IRepository<Models.Entities.Reminder, ReminderDto> repository, ILogger<GetReminderByIdQuery> logger)
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task<ReminderDto?> Handle(GetReminderByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            _logger.LogInformation("Entity with {Id} is not found!", request.Id);
            return default;
        }

        var tags = entity.Tags
            .Select(x => new TagDto { Id = x.Id, Name = x.Name })
            .ToList();

        return new ReminderDto
        {
            Id = entity.Id,
            Content = entity.Content,
            Header = entity.Header,
            NotifyDate = entity.NotifyDate,
            Tags = tags,
        };
    }
}