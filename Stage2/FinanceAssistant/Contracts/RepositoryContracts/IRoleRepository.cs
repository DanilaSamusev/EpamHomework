using System.Collections.Generic;
using Contracts.Entities;

namespace Contracts.RepositoryContracts
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetUserRoles(int userId);
    }
}