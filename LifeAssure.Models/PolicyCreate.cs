using LifeAssure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Models
{
    public class PolicyCreate
    {
        [Required]
        public int PolicyId { get; set; }
        public int? CustomerId { get; set; }
        public int? AgentId { get; set; }
        [Required]
        public PolicyType TypeOfPolicy { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public int PolicyAmount { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Details { get; set; }

    }
}
