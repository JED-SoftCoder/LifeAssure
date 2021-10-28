using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Models
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        public int? AgentId { get; set; }
        public int? PolicyId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
