using MediatR;
using Project.Application.HandlerResponse;

namespace Project.Application.UseCases.Create
{
    public record CreateUserRequest(
        string Email,
        string Password,
        List<Guid> RoleIds
    ) : IRequest<Response>;
}
