using LifeAssure.Data;
using LifeAssure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeAssure.Services
{
    public class PolicyService
    {
        private readonly Guid _userId;

        public PolicyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePolicy(PolicyCreate model)
        {
            var entity =
                new Policy()
                {
                    AdminId = _userId,
                    CustomerId = model.CustomerId,
                    AgentId = model.AgentId,
                    PolicyId = model.PolicyId,
                    TypeOfPolicy = model.TypeOfPolicy,
                    PolicyAmount = model.PolicyAmount,
                    Details = model.Details
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Policies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PolicyListItem> GetPolicies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Policies
                    .Where(e => e.AdminId == _userId)
                    .Select(
                        e =>
                        new PolicyListItem
                        {
                            CustomerId = e.CustomerId,
                            AgentId = e.AgentId,
                            PolicyId = e.PolicyId,
                            TypeOfPolicy = e.TypeOfPolicy,
                            PolicyAmount = e.PolicyAmount,
                            Details = e.Details
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
