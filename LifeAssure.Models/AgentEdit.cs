using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Models
{
    public class AgentEdit
    {
        public int AgentId { get; set; }
        public string Name { get; set; }
        public int LengthOfEmployment { get; set; }
        public bool IsFavorited { get; set; }
    }
}
