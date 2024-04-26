using MediatR;
using Project.Application.DTOs;
using Project.Application.UseCases.DTOs;
using Project.Domain.Entities;
using Project.Domain.Interfaces;

namespace Project.Application.UseCases.Authentication
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            #region Search user in database
            User? user;
            try
            {
                user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
                if (user is null)
                    return new Response("Requisição inválida", 400);
            }
            catch
            {
                return new Response("Não foi possível validar sua requisição", 500);
            }
            #endregion

            #region Validate user password

            #endregion

            await _unitOfWork.Commit(cancellationToken);

            #region
            try
            {
                var data = new UserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = user.Roles,
                };

                return new Response(string.Empty, 201, data);
            }
            catch
            {
                return new Response("Não foi possível obter os dados do perfil", 500);
            }
            #endregion
        }
    }
}
