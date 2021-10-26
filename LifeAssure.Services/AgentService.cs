using LifeAssure.Data;
using LifeAssure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    LengthOfEmployment = model.LengthOfEmployment,
                    NumberOfCustomers = model.NumberOfCustomers,
                    NumberOfPolicies = model.NumberOfPolicies
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
                            NumberOfCustomers = e.NumberOfCustomers,
                            NumberOfPolicies = e.NumberOfPolicies
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
                    .Agents
                    .Single(e => e.AgentId == id && e.AdminId == _userId);
                return
                    new AgentDetail
                    {
                        AgentId = entity.AgentId,
                        Name = entity.Name,
                        LengthOfEmployment = entity.LengthOfEmployment,
                        NumberOfCustomers = entity.NumberOfCustomers,
                        NumberOfPolicies = entity.NumberOfPolicies
                    };
            }
        }
    }
}
