using AutoMapper;
using MediatR;
using Project.Application.DTOs;
using Project.Application.HandlerResponse;
using Project.Domain.Entities;
using Project.Domain.Interfaces;

namespace Project.Application.UseCases.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RefreshTokenHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            //Search user
            User? user;
            try
            {
                // Search user role
                user = await _userRepository.GetUserByRefreshCode(request.RefreshToken, cancellationToken);
                if (user is null)
                {
                    return new Response("User not found", 404);
                }
            }
            catch
            {
                return new Response("Internal Server Error", 500);
            }

            //Update Refresh token
            user.GenerateRefreshToken();

            try
            {
                //Update user in database
                _userRepository.Update(user);
            }
            catch
            {
                return new Response("Internal Server Error", 500);
            }

            // Commit the chages in database
            await _unitOfWork.Commit(cancellationToken);
            //Mapper user to dto
            UserResponseDTO userDTO = _mapper.Map<UserResponseDTO>(user);

            return new Response("Token Refreshed", 200, userDTO);
        }
    }


}
