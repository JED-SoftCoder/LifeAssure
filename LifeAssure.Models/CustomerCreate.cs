using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Models
{
    public class CustomerCreate
    {
        [Required]
        public int CustomerId { get; set; }
        public int? AgentId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        public string Address { get; set; }
    }
}
