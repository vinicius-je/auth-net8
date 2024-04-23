using MediatR;
using Project.Application.UseCases.DTOs;

namespace Project.Application.UseCases.Authentication
{
    public record Request
    (
        string Email,
        string Password
    ) : IRequest<Response>;
}
