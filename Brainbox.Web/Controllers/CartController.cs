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
        public IEnumerable<Cart> GetAll()
        {
            return _cartRepository.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Cart cart)
        {
            var carts = _cartRepository.AddToCart(cart);

            if (cart.Equals("55"))
                return NoContent();

            if (cart.Equals("88"))
                return BadRequest("Quantity exceeds avaliable product");
            
            if (cart.Equals("00"))
                return Ok();

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
