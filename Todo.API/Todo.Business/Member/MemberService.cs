using System.Collections.Generic;
using Todo.Data.Abstract;
using System.Linq;
using Todo.Email;
using Todo.Business;
using System;
using Microsoft.Extensions.Configuration;

namespace Todo.Business.Member
{
    public class MemberService : IMemberService
    {
        private IMemberRepository memberRepository;
        private IConfiguration configuration;

        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }
        public IEnumerable<Model.Member> Get()
        {
            return memberRepository.GetAll();
        }

        public Model.Member GetSingle(int id)
        {
            return memberRepository.GetSingle(id);
        }

        public IEnumerable<Model.Member> GetAdult()
        {
            var result = memberRepository.FindBy(member => member.Age > 18).OrderBy(x => x.Name).ToList();
            //var email = new Todo.Email.Email()
            //{
            //    ToAdress = "",
            //    ToAdressTitle = "",
            //    Subject = "",
            //    BodyContent = result.ToString()
            //};

            //var service = new EmailService(configuration);
            //service.Send(email);

            return result;
        }

        public void Save(Model.Member member)
        {
            memberRepository.Add(member);

            memberRepository.Commit();
        }

        public void Delete(int id)
        {
            Model.Member member = memberRepository.GetSingle(id);

            if (member != null)
            {
                memberRepository.DeleteWhere(x => x.Id == id);

                memberRepository.Commit();
            }
        }

        public void Update(int id, Model.Member member)
        {
            Model.Member aux = memberRepository.GetSingle(id);

            if (member != null && aux.Id == member.Id)
            {
                memberRepository.Update(member);

                memberRepository.Commit();
            }
        }

    }
}

