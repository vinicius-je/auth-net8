using FluentValidation;

namespace Project.Application.UseCases.RefreshToken
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().NotNull();
        }
    }
}
