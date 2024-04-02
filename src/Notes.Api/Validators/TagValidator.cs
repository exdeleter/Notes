using FluentValidation;
using Notes.Models.Dtos;

namespace Notes.Api.Validators;

/// <summary> Валидатор для TagDto. </summary>
public class TagValidator : AbstractValidator<TagDto> 
{
    public TagValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .WithMessage("Необходимо заполнить поле Наименование");
    }
}