using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        // GET api/task/
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/task/1
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/task/
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/task/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/task/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
