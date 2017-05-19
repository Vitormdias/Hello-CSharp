using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Model
{
    public class Team : IEntityBase
    {
        public Team ()
        {
            Members = new List<Member>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}
