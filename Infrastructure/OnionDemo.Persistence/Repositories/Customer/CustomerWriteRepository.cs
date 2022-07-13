using OnionDemo.Application.Repositories;
using OnionDemo.Domain.Entities;
using OnionDemo.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(OnionDemoDbContext context) : base(context)
        {
        }
    }
}
