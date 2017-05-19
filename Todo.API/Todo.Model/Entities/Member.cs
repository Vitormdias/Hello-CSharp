using System;
using System.Collections.Generic;
using System.Text;
using Todo.Model;

namespace Todo.Model
{
    public class Member : IEntityBase
    {
        public Member ()
        {
            Tasks = new List<Task>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Team Team { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
