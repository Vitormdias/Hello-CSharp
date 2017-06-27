using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Model;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Todo.Data
{
    public class TodoDbInitializer
    {
        private static TodoContext context;

        public static void Initialize (IServiceProvider serviceProvider)
        {
            context = (TodoContext)serviceProvider.GetService(typeof(TodoContext));

            InitializeTodo();
        }

        private static void InitializeTodo()
        {
            if (!context.Teams.Any())
            {
                Team team_01 = new Team
                {
                    Name = "Team 1"
                };

                context.Teams.Add(team_01);

                context.SaveChanges();
            }

            if (!context.Members.Any())
            {
                Member member_01 = new Member
                {
                    Name = "Vitor",
                    Age = 19,
                    TeamId = 1
                };

                context.Members.Add(member_01);
                
                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                Model.Task task_01 = new Model.Task()
                {
                    Description = "Fazer Comida",
                    Due = DateTime.Today.AddDays(2),
                    Status = (int)Status.Created,
                    OwnerId = 1
                };

                context.Tasks.Add(task_01);

                context.SaveChanges();
            }
        }
    }
}
