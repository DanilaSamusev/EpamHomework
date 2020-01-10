using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Contracts.Entities;
using Contracts.RepositoryContracts;

namespace DataAccess
{
    public class RoleJsonRepository : IRoleRepository
    {
        private readonly string _connectionString;
        
        public RoleJsonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public void Add(Role obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            var notes = File.ReadAllText(_connectionString);
            
            return JsonSerializer.Deserialize<List<Role>>(notes);
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return GetAll().Where(role => role.UserId == userId);
        }
    }
}