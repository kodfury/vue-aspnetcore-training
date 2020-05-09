using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Dto;
using Server.Models;
//using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET api/user
        [HttpGet("")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.Where(x => x.DeletedAt == null).Select(x => new UserGetAllDto{
                Id = x.Id,
                Username = x.UserName
            }).ToListAsync();
            
            return Ok(users);
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);

            if (user == null)
                return NotFound();

            var userGet = new UserGetAllDto 
            {
                Username = user.UserName,
                Id = user.Id
            };

            return Ok(userGet);
        }

        // POST api/user
        [HttpPost("")]
        public async Task<IActionResult> RegisterUser(UserRegisterDto userRegisterDto)
        {
            var userExist = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userRegisterDto.Username);
            
            if (userExist != null) 
                return BadRequest();
            var userRegister = new User 
            {
                UserName = userRegisterDto.Username,
                Password = userRegisterDto.Password,
                CreatedAt = DateTime.Now
            };
            
            _context.Users.Add(userRegister);
            _context.SaveChanges();

            return Ok(userRegister);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public IActionResult EditUser(int id, UserEditDto userEdit)
        {
            var userToEdit = _context.Users.FirstOrDefault(x => x.Id == id && x.DeletedAt == null);

            if (userToEdit == null)
                return NotFound();

            userToEdit.Email = userEdit.Email;
            userToEdit.Password = userEdit.Password;

            _context.SaveChanges();

            return Ok(userToEdit);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public IActionResult DeletestringById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id && x.DeletedAt == null);
            user.DeletedAt = DateTime.Now;
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult LoginUser(UserRegisterDto userRegister)
        {   
            var user = _context.Users.FirstOrDefault(x => x.UserName == userRegister.Username);

            if (user == null) 
            {
                return BadRequest();
            }

            if (user.Password != userRegister.Password)
            {
                return Unauthorized();
            }

            return Ok(user);
        }
    }
}