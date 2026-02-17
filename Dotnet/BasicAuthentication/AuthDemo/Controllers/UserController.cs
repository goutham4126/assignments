using AuthDemo.Data;
using AuthDemo.DTOs;
using AuthDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext DbContext;

        public UserController(UserContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            var objUser = DbContext.Users.FirstOrDefault(u => u.email == user.email);

            if (objUser == null)
            {
                var newUser = new User
                {
                    firstName = user.firstName,
                    lastName = user.lastName,
                    email = user.email,
                    password = user.password
                };
                DbContext.Users.Add(newUser);
                DbContext.SaveChanges();
                return Ok("user registered successfully");
            }
            else
            {
                return BadRequest("User already exists");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var objUser = DbContext.Users.FirstOrDefault(u => u.email == user.email && u.password == user.password);
            if (objUser != null)
            {
                return Ok("Login successful");
            }
            else
            {
                return BadRequest("Invalid email or password");
            }
        }

        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = DbContext.Users.ToList();

            if(users == null)
            {
                return Ok("No users found");
            }
            return Ok(users);
        }


        [HttpGet("getUserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = DbContext.Users.First(u => u.email == email);
            if(user == null)
            {
                return Ok("No user with that email");
            }
            return Ok(user);
        }



    }
}
