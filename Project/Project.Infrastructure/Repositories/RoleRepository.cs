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

        public async Task<List<Role>> GetRoles(List<Guid> ids)
        {
            return await _context.Roles.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
