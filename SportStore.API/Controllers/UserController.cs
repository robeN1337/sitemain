using Microsoft.AspNetCore.Mvc;
using SportStore.API.Entities;
using SportStore.API.Interfaces;
using SportStore.API.Validations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }


        // GET: api/<UserController>
        [HttpGet]
        public ActionResult GetUsers()
        {
            return Ok(_repo.GetUsers());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult GetUserById(Guid id)
        {
            return Ok(_repo.FindUserById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            var validator = new CapitalLetterValidator();
            var result = validator.Validate(user);
            if (!result.IsValid)
            {
                return StatusCode(500,$"{result.Errors.First().ErrorMessage}");
                //throw new Exception($"{result.Errors.First().ErrorMessage}");
            }
            return Ok(_repo.CreateUser(user));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult UserRedact(User user, Guid id)
        {
            return Ok(_repo.EditUser(user, id));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            return Ok(_repo.DeleteUser(id));
        }
    }
}
