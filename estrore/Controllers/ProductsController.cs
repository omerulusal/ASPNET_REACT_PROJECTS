using estrore.Context;
using estrore.Dtos;
using estrore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace estrore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly UygulamaDbContext _context;
        public ProductsController(UygulamaDbContext context)
        {
            _context = context;
        }

        //Urun Oluşturma
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProductsDto dto)
        {
            var newProduct = new ProductEntity()
            {
                Brand = dto.Brand,
                Title = dto.Title,
                CreatedAt = DateTime.Now
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return Ok("Urun Olusturuldu");
        }



        //Urun Bulma
        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> GetAllProducts()
        {
            var data = _context.Database.GetConnectionString();

            var urunler = await _context.Products.OrderByDescending(q => q.UpdatedAt).ToListAsync();
            return Ok(urunler);
        }



        //Urunun Id sine Göre Bulma
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductByID([FromRoute] long id)
        {
            var urun = await _context.Products.FirstOrDefaultAsync(u => u.ID == id);
            if (urun is null)
            {
                return NotFound("Urun Bulunamadi");
            }
            return Ok(urun);
        }


        //Urun Oluşturma
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] long id, CreateUpdateProductsDto dto)
        {
            var urun = await _context.Products.FirstOrDefaultAsync(u => u.ID == id);
            if (urun is null)
            {
                return NotFound("Urun Bulunamadi");
            }

            urun.Brand = dto.Brand;
            urun.Title = dto.Title;

            await _context.SaveChangesAsync();

            return Ok(urun);

        }




        //Urun Silme
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var urun = await _context.Products.FirstOrDefaultAsync(u => u.ID == id);
            if (urun is null)
            {
                return NotFound("Urun Bulunamadi");
            }
            _context.Products.Remove(urun);
            await _context.SaveChangesAsync();
            return Ok("Urun Silindi");

        }



    }
}
