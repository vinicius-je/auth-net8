using Project.Domain.Entities;

namespace Project.Domain.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<List<Role>> GetRoles(List<Guid> ids);
    }
}
