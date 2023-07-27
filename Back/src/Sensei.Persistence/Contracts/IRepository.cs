using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Sensei.Persistence.Contracts
{
    public interface IRepository
    {
        void Add<T>(T entity) where T: class;
        void AddRange<T>(T [] entities) where T: class;
        void Update<T>(T entity) where T: class;
        void UpdateRange<T>(T entities) where T: class;
        Task<bool> SaveChangesAsync();
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entities) where T: class;
    }
}