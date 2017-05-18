using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Model
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MemberModel> Members { get; set; }
    }
}
