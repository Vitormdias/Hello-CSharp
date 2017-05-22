using Todo.Data.Abstract;
using Todo.Model;

namespace Todo.Data.Repositories
{
    public class MemberRepository : EntityBaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(TodoContext context)
            : base(context)
        { }
    }
}
