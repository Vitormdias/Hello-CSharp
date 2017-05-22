namespace Todo.Data.Abstract
{
    public interface ITaskRepository : IEntityBaseRepository<Model.Task> { }

    public interface IMemberRepository : IEntityBaseRepository<Model.Member> { }

    public interface ITeamRepository : IEntityBaseRepository<Model.Team> { }
}
