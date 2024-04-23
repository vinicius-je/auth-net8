using FluentValidation;

namespace Project.Application.UseCases.Create
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.RoleId).NotEmpty().NotNull();
            RuleFor(x => x.Email).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(100);
        }
    }
}
