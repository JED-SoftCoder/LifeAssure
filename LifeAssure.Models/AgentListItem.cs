using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Models
{
    public class AgentListItem
    {
        [Display(Name="Agent's Id")]
        public int AgentId { get; set; }
        [Display(Name = "Agent's Name")]
        public string Name { get; set; }
        [Display(Name = "Agent's Length Of Employment")]
        public int LengthOfEmployment { get; set; }
        [Display(Name = "Number of Customers Agent oversees")]
        public int NumberOfCustomers { get; set; }
        [Display(Name = "Number of Policies Agent oversees")]
        public int NumberOfPolicies { get; set; }
    }
}
