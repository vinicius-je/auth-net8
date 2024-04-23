using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Infrastructure.Context;

namespace Project.Infrastructure.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Role> GetRoleByName(string name, CancellationToken cancelationToken)
        {
            return _context.Roles.FirstOrDefaultAsync(x => x.Name == name, cancellationToken: cancelationToken);
        }
    }
}
