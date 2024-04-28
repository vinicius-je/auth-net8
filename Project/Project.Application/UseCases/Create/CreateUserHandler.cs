using MediatR;
using Project.Application.HandlerResponse;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces;

namespace Project.Application.UseCases.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHashingService _service;

        public CreateUserHandler(IUserRepository userRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork, IPasswordHashingService service)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _service = service;
        }

        public async Task<Response> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {

            Role? role;
            try
            {
                // Search user role
                role = _roleRepository.GetById(request.RoleId);
                if (role is null)
                {
                    return new Response("Role not found", 404);
                }
            }
            catch
            {
                return new Response("Internal Server Error", 500);
            }

            try
            {
                // Check if email is avaliable
                bool isAvaliable = await _userRepository.AnyAsync(request.Email, cancellationToken);
                if (isAvaliable)
                {
                    return new Response("Email already in use", 404);
                }
            }
            catch
            {
                return new Response("Internal Server Error", 500);
            }

            // Generate User object
            User user = new User(request.Email, _service.HashPassword(request.Password));
            user.addRole(role);
            // Save user in database
            _userRepository.Create(user);
            // Commit the chages in database
            await _unitOfWork.Commit(cancellationToken);

            return new Response("User created", 201);
        }
    }
}
