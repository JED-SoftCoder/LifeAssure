using LifeAssure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Models
{
    public class PolicyListItem
    {
        [Display(Name = "Policy's Id")]
        public int PolicyId { get; set; }
        [Display(Name = "Agent's Id")]
        public int? AgentId { get; set; }
        [Display(Name = "Customer's Id")]
        public int? CustomerId { get; set; }
        [Display(Name = "Type of Policy")]
        public PolicyType TypeOfPolicy { get; set; }
        [Display(Name = "Amount on Policy")]
        public int PolicyAmount { get; set; }
        [Display(Name = "Details of Policy")]
        public string Details { get; set; }
    }
}
