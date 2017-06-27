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
        }

        private static void InitializeTodo()
        {
            if (!context.Members.Any())
            {
                Member member_01 = new Member
                {
                    Name = "Vitor",
                    Age = 19,
                    Tasks = new List<Model.Task>()
                    {
                        new Model.Task()
                        {
                            Description = "Fazer Comida",
                            Due = DateTime.Today.AddDays(2),
                            Status = (int)Status.Created
                        }
                    }
                };

                context.Members.Add(member_01);
                
                context.SaveChanges();
            }

            if (!context.Teams.Any())
            {
                Team team_01 = new Team
                {
                    Name = "Team 1",
                    Members = new List<Member>()
                    {
                        new Member
                        {
                            Id = 1
                            
                        }
                    }
                };
            }
        }
    }
}
