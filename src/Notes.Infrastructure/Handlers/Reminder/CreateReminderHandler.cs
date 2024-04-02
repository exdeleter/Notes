using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Commands.Note;
using Notes.Infrastructure.Commands.Reminder;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Reminder;

public class CreateReminderHandler : IRequestHandler<CreateReminderCommand, Guid>
{
    private readonly IRepository<Models.Entities.Reminder, ReminderDto> _repository;
    private readonly ILogger<CreateReminderHandler> _logger;

    public CreateReminderHandler(IRepository<Models.Entities.Reminder, ReminderDto> repository, ILogger<CreateReminderHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(request.Dto, cancellationToken);
    }
}