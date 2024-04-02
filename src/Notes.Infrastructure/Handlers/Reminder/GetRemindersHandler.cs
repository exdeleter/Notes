using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Queries.Reminder;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Reminder;

/// <summary> Обработчик получения <see cref="Reminder"/>. </summary>
public class GetRemindersHandler : IRequestHandler<GetRemindersQuery, List<ReminderDto>>
{
    private readonly IRepository<Models.Entities.Reminder, ReminderDto> _repository;
    private readonly ILogger<GetRemindersQuery> _logger;

    public GetRemindersHandler(IRepository<Models.Entities.Reminder, ReminderDto> repository, ILogger<GetRemindersQuery> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<List<ReminderDto>> Handle(GetRemindersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);

        var dtos = entities.Select(x => new ReminderDto
        {
            Id = x.Id,
            Content = x.Content,
            Header = x.Header,
            NotifyDate = x.NotifyDate,
            Tags = x.Tags
                .Select(y => new TagDto { Id = y.Id, Name = y.Name })
                .ToList()
        }).ToList();

        return dtos;
    }
}