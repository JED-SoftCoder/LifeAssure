using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Models
{
    public class CustomerListItem
    {
        [Display(Name = "Customer's Id")]
        public int CustomerId { get; set; }
        [Display(Name = "Customer's Agent Id")]
        public int? AgentId { get; set; }
        [Display(Name = "Customer's Full Name")]
        public string Name { get; set; }
        [Display(Name = "Customer's Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Customer's Address")]
        public string Address { get; set; }
        [UIHint("Favorited")]
        public bool IsFavorited { get; set; }
    }
}
