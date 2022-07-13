using OnionDemo.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking);
        Task<T> GetByIdAsync(string id, bool tracking);
    }
}
