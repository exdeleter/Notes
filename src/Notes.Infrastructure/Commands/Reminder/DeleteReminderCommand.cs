using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Commands.Reminder;

/// <summary> Команда для удаления <see cref="ReminderDto"/>. </summary>
/// <param name="Dto">Дто</param>
public record DeleteReminderCommand(ReminderDto Dto) : IRequest<Guid>;