using FluentValidation;

namespace Project.Application.UseCases.RefreshToken
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().NotNull();
        }
    }
}
