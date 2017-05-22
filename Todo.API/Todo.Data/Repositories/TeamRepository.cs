using Todo.Data.Abstract;
using Todo.Model;

namespace Todo.Data.Repositories
{
    public class TeamRepository : EntityBaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(TodoContext context)
            : base(context)
        { }
    }
}
