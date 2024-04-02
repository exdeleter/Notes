using FluentValidation;
using Notes.Models.Dtos;

namespace Notes.Api.Validators;

/// <summary> Валидатор для NoteDto. </summary>
public class NoteValidator : AbstractValidator<NoteDto> 
{
    public NoteValidator()
    {
        RuleFor(dto => dto.Header).NotEmpty().WithMessage("Необходимо заполнить поле Заголовок");
        RuleFor(dto => dto.Content).NotEmpty().WithMessage("Необходимо заполнить поле Текст");
    }
}