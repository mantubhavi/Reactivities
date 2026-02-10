using Application.Activities.Commands;
using Application.Activities.DTOs;
using FluentValidation;

namespace Application.Activities.Validators;

public class EditActivityValidator : BaseActivityValidator<EditActivity.Command, EditActivityDTO>
{
    public EditActivityValidator() : base(x => x.ActivityDTO)
    {
        RuleFor(x => x.ActivityDTO.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}
