using MediatR;
using Microsoft.AspNetCore.Identity;
using Project.Application.Services;
using Project.Application.UseCases.DTOs;
using Project.Domain.Entities;
using Project.Domain.Interfaces;

namespace Project.Application.UseCases.Create
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordHashingService _service;

        public Handler(IUserRepository userRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork, PasswordHashingService service)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _service = service;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {

            Role? role;
            try
            {
                role = _roleRepository.GetById(request.RoleId);
            }
            catch (Exception ex) { }

            // Generate User object
            User user = new User(request.Email, _service.HashPassword(request.Password));
            // Save user in database
            _userRepository.Create(user);
            // Commit the chages
            await _unitOfWork.Commit(cancellationToken);

            return new Response()
        }
    }
}
