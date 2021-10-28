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
                            PolicyId = e.PolicyId,
                            CustomerId = e.CustomerId,
                            AgentId = e.AgentId,
                            TypeOfPolicy = e.TypeOfPolicy,
                            PolicyAmount = e.PolicyAmount,
                            Details = e.Details
                        }
                        );
                return query.ToArray();
            }
        }

        public PolicyDetail GetPolicyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Policies
                    .Single(e => e.PolicyId == id && e.AdminId == _userId);
                return
                    new PolicyDetail
                    {
                        PolicyId = entity.PolicyId,
                        CustomerId = entity.CustomerId,
                        AgentId = entity.AgentId,
                        TypeOfPolicy = entity.TypeOfPolicy,
                        PolicyAmount = entity.PolicyAmount,
                        Details = entity.Details
                    };
            }
        }

        public bool UpdatePolicy(PolicyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Policies
                    .Single(e => e.PolicyId == model.PolicyId && e.AdminId == _userId);

                entity.CustomerId = model.CustomerId;
                entity.AgentId = model.AgentId;
                entity.TypeOfPolicy = model.TypeOfPolicy;
                entity.PolicyAmount = model.PolicyAmount;
                entity.Details = model.Details;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePolicy(int policyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Policies
                    .Single(e => e.PolicyId == policyId && e.AdminId == _userId);

                ctx.Policies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
