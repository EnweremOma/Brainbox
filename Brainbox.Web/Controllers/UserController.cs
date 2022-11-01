using Brainbox.Domain.Models;
using Brainbox.Domain.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brainbox.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _db;
        public UserController(IUserRepository db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Create(User user)
        {
            bool alreadyExists = _db.Add(user, x => x.Email == user.Email);
            if (!alreadyExists)
            {
                if (_db.Save() <= 0)
                    return BadRequest("Something went wrong pleas try again later.");

                return CreatedAtAction(nameof(GetAll), new { id = user.UserId }, user);
            }
            return Conflict("user already exists.");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, User user)
        {
            if (id != user.UserId) return BadRequest("User does not exist");

            _db.Update(user);
            _db.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var userToDelete = _db.GetFirstOrDefault(x => x.UserId == id);
            if (userToDelete == null) return NotFound();

            _db.Remove(userToDelete);
            _db.Save();

            return NoContent();
        }
    }
}
