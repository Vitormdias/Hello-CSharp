using System;
using System.Collections.Generic;
using System.Text;
using Todo.Model;
using Todo.Data.Abstract;
using System.Linq;
using Todo.Email;

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
            var result = memberRepository.FindBy(member => member.Age > 18).OrderBy(x => x.Name).ToList();
            var email = new Todo.Email.Email()
            {
                ToAdress = "",
                ToAdressTitle = "",
                Subject = "",
                BodyContent = result.ToString()
            };

            var service = new EmailService();
            service.Send(email);

            return result;
        }
    }
}
