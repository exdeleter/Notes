﻿using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Commands.Reminder;

/// <summary> Команда для обновления <see cref="ReminderDto"/>. </summary>
/// <param name="Dto">Дто</param>
public record UpdateReminderCommand(ReminderDto Dto) : IRequest<ReminderDto>;