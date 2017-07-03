using System;
using System.Collections.Generic;
using System.Text;
using Todo.Business.Member;
using Todo.Data.Abstract;
using Xunit;

namespace Todo.Tests
{
    public class TestMemberService
    {
        private IMemberRepository memberRepository;
        //private MemberService memberService;

        public TestMemberService()
        {
            //memberService = new MemberService(memberRepository);
        }

        [Fact]
        public void TestGetAdult()
        {
            var service = new MemberService(memberRepository);
            var result = service.GetAdult();
       
            Assert.True(result != null);
        }

    }
}
