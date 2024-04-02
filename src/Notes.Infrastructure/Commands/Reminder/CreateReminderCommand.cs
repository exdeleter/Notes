using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Commands.Reminder;

/// <summary> Команда для создания <see cref="ReminderDto"/>. </summary>
/// <param name="Dto">Дто</param>
public record CreateReminderCommand(ReminderDto Dto) : IRequest<Guid>;