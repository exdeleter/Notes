using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Commands.Note;
using Notes.Infrastructure.Commands.Reminder;
using Notes.Infrastructure.Handlers.Note;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Reminder;

public class DeleteReminderHandler : IRequestHandler<DeleteReminderCommand, Guid>
{
    private readonly IRepository<Models.Entities.Reminder, ReminderDto> _repository;
    private readonly ILogger<DeleteReminderHandler> _logger;

    public DeleteReminderHandler(IRepository<Models.Entities.Reminder, ReminderDto> repository, ILogger<DeleteReminderHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Dto, cancellationToken);
        
        return request.Dto.Id;
    }
}