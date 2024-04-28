using MediatR;
using Project.Application.HandlerResponse;

namespace Project.Application.UseCases.RefreshToken
{
    public record RefreshTokenRequest(
        Guid RefreshToken
    ) : IRequest<Response>;
}
