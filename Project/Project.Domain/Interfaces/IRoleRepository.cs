using Project.Domain.Entities;

namespace Project.Domain.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetRoleByName(string name, CancellationToken cancelationToken);
    }
}
