using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Queries.Reminder;

/// <summary> Квери для получения <see cref="Reminder"/>. </summary>
public record GetRemindersQuery : IRequest<List<ReminderDto>>;