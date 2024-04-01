using FluentValidation;

namespace FluentValidationAPI;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(user => user.Age).InclusiveBetween(18, 99).WithMessage("Age must be between 18 and 99.");
    }
}
