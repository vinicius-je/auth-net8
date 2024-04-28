using MediatR;
using Project.Application.HandlerResponse;

namespace Project.Application.UseCases.Create
{
    public record CreateUserRequest(
        string Email,
        string Password,
        Guid RoleId
    ) : IRequest<Response>;
}
