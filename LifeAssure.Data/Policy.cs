using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Data
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        [Required]
        public Guid AdminId { get; set; }
        [ForeignKey(nameof(Agent))]
        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public Guid TypeOfPolicy { get; set; }
        [Required]
        public double PolicyAmount { get; set; }
        [Required]
        public string Details { get; set; }
    }
}
