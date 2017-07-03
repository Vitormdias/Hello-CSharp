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
        private IMemberRepository memberRepository;
        
        public MemberController(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }
        // GET api/member
        [HttpGet]
        public IEnumerable<Member> Get()
        {
            var member = new MemberService(memberRepository);

            return member.Get();
        }

        // GET api/values/5
        //[Authorize]
        [HttpGet("{id}")]
        public Member Get(int id)
        {
            var member = new MemberService(memberRepository);

            return member.GetSingle(id);
        }

        public IEnumerable<Member> GetAdult ()
        {
            var member = new MemberService(memberRepository);

            return member.GetAdult();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Member value)
        {
            var member = new MemberService(memberRepository);

            member.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Member value)
        {
            var member = new MemberService(memberRepository);

            member.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var member = new MemberService(memberRepository);

            member.Delete(id);
        }
    }
}
