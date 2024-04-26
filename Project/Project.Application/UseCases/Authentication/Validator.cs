using FluentValidation;

namespace Project.Application.UseCases.Authentication
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Email).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.RoleId).NotNull();
        }
    }
}
