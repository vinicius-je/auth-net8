using Project.Domain.Entities;

namespace Project.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        public Task<User?> GetUserByRefreshCode(Guid refreshToken, CancellationToken cancellationToken);
        Task<bool> AnyAsync(string email, CancellationToken cancelationToken);
    }
}
