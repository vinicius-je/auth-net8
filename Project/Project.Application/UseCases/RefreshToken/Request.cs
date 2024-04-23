using MediatR;
using Project.Application.UseCases.DTOs;

namespace Project.Application.UseCases.RefreshToken
{
    public record Request(
        Guid RefreshToken
    ) : IRequest<Response>;
}
