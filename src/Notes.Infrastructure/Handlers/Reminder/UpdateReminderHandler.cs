using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Commands.Reminder;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Reminder;

/// <summary> Обработчик обновления <see cref="Reminder"/>. </summary>
public class UpdateReminderHandler : IRequestHandler<UpdateReminderCommand, ReminderDto?>
{
    private readonly IRepository<Models.Entities.Reminder, ReminderDto> _repository;
    private readonly ILogger<UpdateReminderHandler> _logger;

    public UpdateReminderHandler(IRepository<Models.Entities.Reminder, ReminderDto> repository, ILogger<UpdateReminderHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<ReminderDto?> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.Dto, cancellationToken);

        return request.Dto;
    }
}