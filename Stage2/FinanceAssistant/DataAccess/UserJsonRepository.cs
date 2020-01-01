using System.Collections.Generic;
using Contracts.Models;
using Contracts.RepositoryContracts;

namespace DataAccess
{
    public class UserJsonRepository : IUserRepository
    {
        public void Add(User obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}