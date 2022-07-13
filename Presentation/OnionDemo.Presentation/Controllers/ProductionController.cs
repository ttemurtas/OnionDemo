using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application.Repositories;
using OnionDemo.Persistence.Contexts;
using OnionDemo.Persistence.Repositories;

namespace OnionDemo.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly OnionDemoDbContext _context;
        private readonly IProductWriteRepository productWriteRepository;

        public ProductionController(IProductWriteRepository productWriteRepository, OnionDemoDbContext context)
        {
            _context = context;
            this.productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public Task AddProduct()
        {
            var result = productWriteRepository.AddRangeAsync(new()
            {
                new() { CreateDate = DateTime.UtcNow, Id = Guid.NewGuid(), Name = "Product 1", Price = 10, Stock = 100 },
                new() { CreateDate = DateTime.UtcNow, Id = Guid.NewGuid(), Name = "Product 2", Price = 40, Stock = 500 },
                new() { CreateDate = DateTime.UtcNow, Id = Guid.NewGuid(), Name = "Product 3", Price = 80, Stock = 200 },
            });

            _context.SaveChanges();

            return result;
        }
    }
}
