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
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            // Get all product items from the database
            return Ok(_db.GetAll());
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            // Get a product by Product id 
            var product =  _db.GetFirstOrDefault(x=>x.Id == id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Create(Product product)
        {
            //Create a new product
            bool alreadyExists = _db.Add(product, x => x.Name == product.Name);
            if (!alreadyExists)
            {
                if (_db.Save() <= 0)
                    return BadRequest("Something went wrong pleas try again later.");

                return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
            }
              return Conflict("Product already exists.");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, Product product)
        {
            //Edit a single product item
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
            //Delete a single product item
            var productToDelete =  _db.GetFirstOrDefault(x => x.Id == id);
            if (productToDelete == null) return NotFound();

            _db.Remove(productToDelete);
            _db.Save();

            return NoContent();
        }
    }
}
