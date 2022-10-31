using Brainbox.Domain.Models;
using Brainbox.Domain.Repository;
using Brainbox.Domain.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Brainbox.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _db;
        public ProductController(IProductRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return  _db.GetAll();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var product =  _db.GetFirstOrDefault(x=>x.Id == id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Product product)
        {
            _db.Add(product);

            if (_db.Save() > 0) 
            {
                return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
            }
            else
            {
                return BadRequest();
            }

            
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();

            _db.Update(product);
            _db.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var productToDelete =  _db.GetFirstOrDefault(x => x.Id == id);
            if (productToDelete == null) return NotFound();

            _db.Remove(productToDelete);
            _db.Save();

            return NoContent();
        }
    }
}
