using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Model
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public MemberModel Owner { get; set; }
        public DateTime Due { get; set; }
    }
}
