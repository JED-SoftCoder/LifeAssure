using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
        public Guid AdminId { get; set; }
        [ForeignKey(nameof(Agent))]
        public int? AgentId { get; set; }
        public virtual Agent Agent { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [DefaultValue(false)]
        public bool IsFavorited { get; set; }
    }
}
