using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Business.Member
{
    public interface IMemberService 
    {
        IEnumerable<Model.Member> Get();
        Model.Member GetSingle(int id);
        IEnumerable<Model.Member> GetAdult();
        void Save(Model.Member member);
        void Delete(int id);
        void Update(int id, Model.Member member);
    }
}
