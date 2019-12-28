using System.Collections.Generic;

namespace Contracts.RepositoryContracts
{
    public interface IRepository<T>
    {
        void Add(T obj);
        
        IEnumerable<T> GetAll();
    }
}