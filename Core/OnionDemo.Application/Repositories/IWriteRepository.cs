﻿using OnionDemo.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);

        bool Remove(T model);
        Task<bool> RemoveAsync(string id);
        bool RemoveRangeAsync(List<T> model);

        bool UpdateAsync(T model);
        Task<bool> UpdateAsync(string id);
        bool UpdateRangeAsync(List<T> model);
    }
}
