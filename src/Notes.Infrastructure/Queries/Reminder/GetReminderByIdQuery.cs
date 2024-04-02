using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Queries.Reminder;

/// <summary> Квери для получения всех <see cref="Reminder"/>. </summary>
public record GetReminderByIdQuery(Guid Id) : IRequest<ReminderDto>;