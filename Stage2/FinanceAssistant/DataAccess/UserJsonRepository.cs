using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Contracts.Models;
using Contracts.RepositoryContracts;

namespace DataAccess
{
    public class UserJsonRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserJsonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public void Add(User obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var notes = File.ReadAllText(_connectionString);
            
            return JsonSerializer.Deserialize<List<User>>(notes);
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetByPassword(string password)
        {
            return GetAll().FirstOrDefault(user => user.Password == password);
        }
    }
}