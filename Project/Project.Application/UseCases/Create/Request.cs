using MediatR;
using Project.Application.DTOs;
using Project.Application.UseCases.DTOs;

namespace Project.Application.UseCases.Create
{
    public record Request(
        string Email,
        string Password,
        Guid RoleId
    ) : IRequest<Response>;
}
