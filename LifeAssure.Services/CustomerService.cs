using LifeAssure.Data;
using LifeAssure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    AdminId = _userId,
                    CustomerId = model.CustomerId,
                    AgentId = model.AgentId,
                    //PolicyId = model.PolicyId,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Where(e => e.AdminId == _userId)
                    .Select(
                        e =>
                        new CustomerListItem
                        {
                            CustomerId = e.CustomerId,
                            AgentId = e.AgentId,
                            //PolicyId = e.PolicyId,
                            Name = e.Name,
                            PhoneNumber = e.PhoneNumber,
                            Address = e.Address
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
