using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Model;
using Microsoft.AspNetCore.Authorization;
using Todo.Data.Abstract;
using Todo.Business.Member;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private IMemberService memberService;
        
        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }
        // GET api/member
        [HttpGet]
        public IEnumerable<Member> Get()
        {
            return memberService.GetAdult();
        }

        // GET api/values/5
        //[Authorize]
        [HttpGet("{id}")]
        public Member Get(int id)
        {
            return memberService.GetSingle(id);
        }

        public IEnumerable<Member> GetAdult ()
        {
            return memberService.GetAdult();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Member value)
        {
            memberService.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Member value)
        {
            memberService.Update(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            memberService.Delete(id);
        }
    }
}
