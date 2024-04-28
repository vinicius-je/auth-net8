using MediatR;
using Project.Application.HandlerResponse;

namespace Project.Application.UseCases.Authentication
{
    public record AuthenticationRequest
    (
        string Email,
        string Password
    ) : IRequest<Response>;
}
