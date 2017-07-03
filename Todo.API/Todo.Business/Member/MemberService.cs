﻿using System.Collections.Generic;
using Todo.Data.Abstract;
using System.Linq;

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

        public Model.Member GetSingle (int id)
        {
            return memberRepository.GetSingle(id);
        }

        public IEnumerable<Model.Member> GetAdult()
        {
            return memberRepository.FindBy(member => member.Age > 18).OrderBy(x => x.Name).ToList();
        }

        public void Save (Model.Member member)
        {
            memberRepository.Add(member);

            memberRepository.Commit();
        }

        public void Delete (int id)
        {
            Model.Member member = memberRepository.GetSingle(id);

            if (member != null)
            {
                memberRepository.DeleteWhere(x => x.Id == id);

                memberRepository.Commit();
            }
        }

        public void Update(Model.Member member)
        {
            
            memberRepository.Update(member);
        }
    }
}

