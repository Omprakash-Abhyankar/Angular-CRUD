using CRUDDemoAPI.Context;
using CRUDDemoAPI.Model;
using CRUDDemoAPI.Model.Viewmodel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> CreateProduct(Products products)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          products.ProductId = new Guid();
            //_context.Products.Add(products);
            _context.products.Add(products);
            await _context.SaveChangesAsync();
            return Ok("Product Added Successfully");
        }

        [HttpGet("GetProduct")]
        public async Task<IEnumerable<Products>> GetProduct()
        {
            return await _context.products.ToListAsync();
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
        public async Task<IActionResult> UpdateProducts(Products products)
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
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPatch("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct()
        {
            return View();
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
            return Ok();
        }
    }
}
