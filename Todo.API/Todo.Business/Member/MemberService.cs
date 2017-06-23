using System;
using System.Collections.Generic;
using System.Text;
using Todo.Model;
using Todo.Data.Abstract;

namespace Todo.Business.Member
{
    public class MemberService
    {
        private IMemberRepository memberRepository ;
        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }
        public IEnumerable<Model.Member> Get ()
        {
            return memberRepository.GetAll();
        }
    }
}
