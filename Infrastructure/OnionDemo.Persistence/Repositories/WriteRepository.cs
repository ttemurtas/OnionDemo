using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionDemo.Application.Repositories;
using OnionDemo.Domain.Entities.Common;
using OnionDemo.Persistence.Contexts;

namespace OnionDemo.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly OnionDemoDbContext _context;

        public WriteRepository(OnionDemoDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            await Table.AddAsync(model);

            return true;
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);

            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry entity = Table.Remove(model);

            return entity.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            Table.Remove(entity);

            return true;
        }

        public bool RemoveRangeAsync(List<T> model)
        {
            Table.RemoveRange(model);

            return true;
        }

        public bool UpdateAsync(T model)
        {
            EntityEntry entity = Table.Update(model);

            return entity.State == EntityState.Modified;
        }

        public async Task<bool> UpdateAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            EntityEntry entityEntry = Table.Update(model);

            return entityEntry.State == EntityState.Modified;
        }

        public bool UpdateRangeAsync(List<T> model)
        {
            Table.UpdateRange(model);

            return true;
        }
    }
}
