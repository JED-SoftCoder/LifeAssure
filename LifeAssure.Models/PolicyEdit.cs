using LifeAssure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Models
{
    public class PolicyEdit
    {
        public int PolicyId { get; set; }
        public int? CustomerId { get; set; }
        public int? AgentId { get; set; }
        public PolicyType TypeOfPolicy { get; set; }
        public int PolicyAmount { get; set; }
        public string Details { get; set; }
    }
}
