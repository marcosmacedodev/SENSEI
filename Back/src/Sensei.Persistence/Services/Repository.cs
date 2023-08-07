using Sensei.Persistence.Contracts;
using Sensei.Persistence.DataContext;

namespace Sensei.Persistence.Services
{
    public class Repository : IRepository
    {
        private readonly SenseiContext _context;
        public Repository(SenseiContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void AddRange<T>(T[] entities) where T : class
        {
            _context.AddRange(entities);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entities) where T : class
        {
            _context.RemoveRange(entities);
        }

        public async Task<bool> FindByIdAsync<T>(int id)
        {
            return await _context.FindAsync(typeof(T), id) != null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void UpdateRange<T>(T entities) where T : class
        {
            _context.UpdateRange(entities);
        }
    }
}