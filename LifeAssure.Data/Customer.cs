using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(Agent))]
        public int? AgentId { get; set; }
        public virtual Agent Agent { get; set; }
        [ForeignKey(nameof(Policy))]
        public int? PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public int YearsOfPolicy { get; set; }
    }
}
