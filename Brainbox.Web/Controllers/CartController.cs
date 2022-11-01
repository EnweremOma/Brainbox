using Brainbox.Domain.Models;
using Brainbox.Domain.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brainbox.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_cartRepository.GetAllCarts());
        }

        [HttpGet("id")]
        public IActionResult GetCartByUserId(int id)
        {
            return Ok(_cartRepository.GetAllCartByUserId(id));
        }

        [HttpGet("userId")]
        public IActionResult GetCartTotal(int id)
        {
            return Ok(_cartRepository.CartTotal(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Create(Cart cart)
        {
            var addCarts = _cartRepository.AddToCart(cart);

            if (addCarts.Equals("55"))
                return NoContent();

            if (addCarts.Equals("88"))
                return BadRequest("Quantity exceeds avaliable product");
            
            if (addCarts.Equals("00"))
                return Ok(cart);

            return BadRequest("Oops! something went wrong.");

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var cartToDelete = _cartRepository.GetFirstOrDefault(x => x.Id == id);
            if (cartToDelete == null) return NotFound();

            _cartRepository.Remove(cartToDelete);
            _cartRepository.Save();

            return NoContent();
        }
    }
}
