using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.HandlerResponse;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces;

namespace Project.Application.UseCases.Authentication
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationRequest, Response>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHashingService _service;

        public AuthenticationHandler(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IPasswordHashingService service)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
        }

        public async Task<Response> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            User? user;
            try
            {
                // Search user in database
                user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
                if (user is null)
                    return new Response("User not found", 404);
            }
            catch
            {
                return new Response("Internal Server Error", 500);
            }


            // Validate user password
            bool isVerified = _service.VerifyHashedPassword(user.Password, request.Password);
            if (!isVerified)
            {
                return new Response("Password dont match", 404);
            }
            // Commit the chages in database
            await _unitOfWork.Commit(cancellationToken);
            // Mapper user to DTO
            UserResponseDTO userDTO = _mapper.Map<UserResponseDTO>(user);
            return new Response("User authenticated", 200, userDTO);
        }
    }
}
