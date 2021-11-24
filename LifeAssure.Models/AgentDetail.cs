using LifeAssure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Models
{
    public class AgentDetail
    {
        [Display(Name = "Agent's Id")]
        public int AgentId { get; set; }
        [Display(Name = "Agent's Name")]
        public string Name { get; set; }
        [Display(Name = "Agent's Length Of Employment")]
        public int LengthOfEmployment { get; set; }
        [Display(Name = "Customers Agent oversees:")]
        public List<CustomerListItem> Customers { get; set; }
        [Display(Name = "Policies Agent oversees:")]
        public List<PolicyListItem> Policies { get; set; }
    }
}
