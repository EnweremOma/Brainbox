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
        private readonly ICartRepository _db;
        public CartController(ICartRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Cart> GetAll()
        {
            return _db.GetAll();
        }


    }
}
