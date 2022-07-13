using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Repositories;
using OnionDemo.Domain.Entities.Common;
using OnionDemo.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly OnionDemoDbContext _context;

        public ReadRepository(OnionDemoDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking)
        {
            var query = Table.Where(predicate).AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(predicate);

        }
        public async Task<T> GetByIdAsync(string id, bool tracking)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        }
    }
}
