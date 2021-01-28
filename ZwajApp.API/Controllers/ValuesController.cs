using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZwajApp.API.Model;

namespace ZwajApp.API.Controllers
{    //http://localhost:5000/api/values
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly dbcontext _context;
        public ValuesController(dbcontext context)
        {
            _context = context;

        }
        // GET api/values
          [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Getvalue()
       {
           var values=await _context.Users.ToListAsync();
          return Ok(values);
        }

        // GET api/values/5
        // public IEnumerable<value> getvalue(){
            // var values=_context.values.ToList();
            // return values;
        // }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Getvalues(int id)
        {
            var value=_context.values.FirstOrDefault(x=>x.ID==id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
