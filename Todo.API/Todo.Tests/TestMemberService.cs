using System;
using System.Collections.Generic;
using Todo.Business.Member;
using Todo.Model;
using Todo.Tests;
using Xunit;

namespace Todo.Test
{
    public class TestMemberService
    {
        public IMemberService memberService;
        private TestMemberRepository memberRepository;
        private Member member;
        private List<Member> list;

        public TestMemberService()
        {
            member = new Member
            {
                Id = 1,
                Name = "Vitor",
                Age = 19,
                TeamId = 1
            };

            list = new List<Member>();
            list.Add(member);

            memberRepository = new TestMemberRepository(list);
            memberService = new MemberService(memberRepository);
        }

        [Fact]
        public void TestGetMember()
        {
            var result = memberService.Get();
            Assert.Equal(list, result);
        }

        [Theory]
        [InlineData(1)]
        public void TestGetSingleMember(int id)
        {
            var result = memberService.GetSingle(id);
            Assert.Equal(member, result);
        }

        [Fact]
        public void AddAndFoundMember()
        {
            var m = new Member
            {
                Id = 2,
                Name = "Medson",
                Age = 20,
                TeamId = 1
            };

            memberService.Save(m);
            var result = memberService.GetSingle(m.Id);
            Assert.Equal(m, result);
        }
    }
}
