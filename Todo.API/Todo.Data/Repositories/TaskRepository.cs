using Todo.Data.Abstract;
using Todo.Model;

namespace Todo.Data.Repositories
{
    public class TaskRepository : EntityBaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(TodoContext context)
            : base(context)
        { }
    }
}
