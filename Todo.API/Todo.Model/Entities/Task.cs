using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Model
{
    public class Task : IEntityBase
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Member Owner { get; set; }
        public DateTime Due { get; set; }
        public int Status { get; set; }
    }
}
