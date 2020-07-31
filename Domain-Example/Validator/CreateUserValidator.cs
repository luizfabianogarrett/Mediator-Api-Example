using Domain_Example.Command;
using FluentValidation;

namespace Domain_Example.Validator
{
    public class CreateUserValidator : AbstractValidator<NewPersonCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório");

        }
    }
}
