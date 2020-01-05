using Contracts.Models;

namespace Contracts.RepositoryContracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByPassword(string password);
    }
}