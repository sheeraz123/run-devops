using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using shopping.api.Data;
using shopping.api.Models;

namespace shopping.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _context;
        public ProductController(ILogger<ProductController> logger, ProductContext context )
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            //return ProductContext.Products;

            return await _context
                          .Products
                          .Find(p => true)
                          .ToListAsync();
        }
    }
}
