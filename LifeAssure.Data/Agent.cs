using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Data
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        [Required]
        public string Name { get; set; }
        public int LengthOfEmployment { get; set; }
        public int NumberOfCustomers { get; set; }
        public int NumberOfPolicies { get; set; }
    }
}
