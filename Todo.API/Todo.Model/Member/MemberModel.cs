using System;
using System.Collections.Generic;
using System.Text;
using Todo.Model;

namespace Todo.Model
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public TeamModel Team { get; set; }
        public ICollection<TaskModel> Tasks { get; set; }
    }
}
