using CRUDDemoAPI.Context;
using CRUDDemoAPI.Model;
using CRUDDemoAPI.Model.Viewmodel;
using CRUDDemoAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUDDemoAPI.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ProductController
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductDto products)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            products.ProductId = new Guid();
            Products pro = new Products()
            {
                ProductId = products.ProductId,
                productName = products.productName,
                category = products.category,
                freshness = products.freshness,
                price = products.price,
                comment = products.comment,
                date = products.date
            };
            //_context.Products.Add(products);
            _context.products.Add(pro);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Product Added Successfully" });
        }

        [HttpGet("GetProduct")]
        public async Task<ActionResult<List<ProductDto>>> GetProduct()
        {
           var productList =  await _context.products.ToListAsync();

            var productDtoList = productList
           .Select(products => new ProductDto
           {
               ProductId = products.ProductId,
               productName = products.productName,
               category = products.category,
               freshness = products.freshness,
               price = products.price,
               comment = products.comment,
               date = products.date
           }).ToList();
            return Ok(productDtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            if (id.ToString().Length == 0)
                return BadRequest();
            var product = await _context.products.FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpPut("UpdateProducts")]
        public async Task<IActionResult> UpdateProducts(ProductDto products)
        {
            if (products == null || products.ProductId.ToString().Length == 0)
                return BadRequest();

            var product = await _context.products.FindAsync(products.ProductId);

            if (product == null)
                return NotFound();
            product.productName = products.productName;
            product.category = products.category;
            product.freshness = products.freshness;
            product.price = products.price;
            product.comment = products.comment;
            product.date = products.date;
            _context.products.Update(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
      
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (id.ToString().Length == 0)
                return BadRequest();
            var product = await _context.products.FindAsync(id);
            if (product == null)
                return NotFound();
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Product Deleted Successfully" });
            
        }
    }
}
