using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
//using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly DataContext _context;
        public ValueController(DataContext context)
        {
            _context = context;
        }

        // GET api/value
        [HttpGet("")]
        public IActionResult Getstrings()
        {
            var values = _context.Values.ToList();

            return Ok(values);
        }

        // GET api/value/5
        [HttpGet("{id}")]
        public IActionResult GetstringById(int id)
        {
            var value = _context.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }

        // POST api/value
        [HttpPost("")]
        public void Poststring(string value)
        {
        }

        // PUT api/value/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {
        }

        // DELETE api/value/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
        }
    }
}