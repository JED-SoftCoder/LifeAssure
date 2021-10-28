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
                            Name = e.Name,
                            PhoneNumber = e.PhoneNumber,
                            Address = e.Address
                        }
                        );
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == id && e.AdminId == _userId);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        AgentId = entity.AgentId,
                        Name = entity.Name,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == model.CustomerId && e.AdminId == _userId);

                entity.Name = model.Name;
                entity.AgentId = model.AgentId;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Address = model.Address;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == customerId && e.AdminId == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
