using Brainbox.Domain.Models;
using Brainbox.Domain.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brainbox.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryRepository _db;
        public ProductCategoryController(IProductCategoryRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ProductCategory> GetAll()
        {
            return _db.GetAll();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(ProductCategory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var productCategory = _db.GetFirstOrDefault(x => x.Id == id);
            return productCategory == null ? NotFound() : Ok(productCategory);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Create(ProductCategory productCategory)
        {
            bool alreadyExists = _db.Add(productCategory, x => x.Name == productCategory.Name);
            if (!alreadyExists)
            {
                if (_db.Save() <= 0)
                    return BadRequest("Something went wrong pleas try again later.");

                return CreatedAtAction(nameof(GetAll), new { id = productCategory.Id }, productCategory);
            }
            return Conflict("Product category already exists.");

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, ProductCategory productCategory)
        {
            if (id != productCategory.Id) return BadRequest("Something went wrong pleas try again later.");

            _db.Update(productCategory);
            _db.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var productCategoryToDelete = _db.GetFirstOrDefault(x => x.Id == id);
            if (productCategoryToDelete == null) return NotFound();

            _db.Remove(productCategoryToDelete);
            _db.Save();

            return NoContent();
        }
    }
}
