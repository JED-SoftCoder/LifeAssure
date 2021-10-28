using LifeAssure.Data;
using LifeAssure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LifeAssure.Services
{
    public class AgentService
    {
        private readonly Guid _userId;

        public AgentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAgent(AgentCreate model)
        {
            var entity =
                new Agent()
                {
                    AdminId = _userId,
                    AgentId = model.AgentId,
                    Name = model.Name,
                    LengthOfEmployment = model.LengthOfEmployment
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Agents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AgentListItem> GetAgents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Agents
                    .Where(e => e.AdminId == _userId)
                    .Select(
                        e =>
                        new AgentListItem
                        {
                            AgentId = e.AgentId,
                            Name = e.Name,
                            LengthOfEmployment = e.LengthOfEmployment,
                            NumberOfCustomers = e.Customers.Count,
                            NumberOfPolicies = e.Policies.Count
                        }
                        );
                return query.ToArray();
            }
        }

        public AgentDetail GetAgentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Agents.Include(a => a.Customers)
                    .Single(e => e.AgentId == id && e.AdminId == _userId);
                return
                    new AgentDetail
                    {
                        AgentId = entity.AgentId,
                        Name = entity.Name,
                        LengthOfEmployment = entity.LengthOfEmployment,
                        Customers = entity.Customers.Select(c => new CustomerListItem
                        {
                            CustomerId = c.CustomerId,
                            AgentId = c.AgentId,
                            Name = c.Name,
                            PhoneNumber = c.PhoneNumber,
                            Address = c.Address
                        }).ToList(),
                        Policies = entity.Policies.Select(p => new PolicyListItem
                        {
                            CustomerId = p.CustomerId,
                            AgentId = p.AgentId,
                            PolicyId = p.PolicyId,
                            TypeOfPolicy = p.TypeOfPolicy,
                            PolicyAmount = p.PolicyAmount,
                            Details = p.Details
                        }).ToList()
                    };
            }
        }

        public bool UpdateAgent(AgentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Agents
                    .Single(e => e.AgentId == model.AgentId && e.AdminId == _userId);

                entity.Name = model.Name;
                entity.LengthOfEmployment = model.LengthOfEmployment;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAgent(int agentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Agents
                    .Single(e => e.AgentId == agentId && e.AdminId == _userId);

                ctx.Agents.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
