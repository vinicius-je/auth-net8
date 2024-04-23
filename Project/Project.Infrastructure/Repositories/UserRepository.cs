using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Infrastructure.Context;

namespace Project.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<bool> AnyAsync(string email, CancellationToken cancelationToken)
        {
            return _context.Users
                        .AsNoTracking()
                        .AnyAsync(x => x.Email == email, cancelationToken);
        }

        public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _context.Users
                        .AsNoTracking()
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public Task<User?> GetUserByRefreshCode(Guid refreshToken, CancellationToken cancellationToken)
        {
            return _context.Users
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken, cancellationToken: cancellationToken);
        }
    }
}
