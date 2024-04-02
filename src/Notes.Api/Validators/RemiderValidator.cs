using FluentValidation;
using Notes.Models.Dtos;

namespace Notes.Api.Validators;

/// <summary> Валидатор для ReminderDto. </summary>
public class ReminderValidator : AbstractValidator<ReminderDto> 
{
    public ReminderValidator()
    {
        RuleFor(dto => dto.Header).NotEmpty().WithMessage("Необходимо заполнить поле Заголовок");
        RuleFor(dto => dto.Content).NotEmpty().WithMessage("Необходимо заполнить поле Текст");
        RuleFor(dto => dto.NotifyDate).NotEmpty().WithMessage("Необходимо заполнить поле Время напоминания");
    }
}