using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Guid AdminId { get; set; }
        [Required]
        public string Name { get; set; }
        public int LengthOfEmployment { get; set; }
        public virtual List<Customer> Customers { get; set; }
        public virtual List<Policy> Policies { get; set; }
        [DefaultValue(false)]
        public bool IsFavorited { get; set; }
    }
}
