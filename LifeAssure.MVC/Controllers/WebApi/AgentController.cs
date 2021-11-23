using LifeAssure.Models;
using LifeAssure.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;

namespace LifeAssure.MVC.Controllers.WebApi
{
        [System.Web.Http.Authorize]
        [System.Web.Http.RoutePrefix("api/agent")]
        public class AgentController : ApiController
        {
            private bool SetStarState(int agentId, bool newState)
            {
                //Create service
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new AgentService(userId);

                //Get agent
                var detail = service.GetAgentById(agentId);

                //Create AgentEdit model instance with new star state
                var updatedAgent =
                    new AgentEdit
                    {
                        AgentId = detail.AgentId,
                        Name = detail.Name,
                        LengthOfEmployment = detail.LengthOfEmployment,
                        IsFavorited = newState
                    };

                //Return value indicating whether the update succeeded
                return service.UpdateAgent(updatedAgent);
            }

            [System.Web.Http.Route("{id}/Star")]
            [System.Web.Http.HttpPut]
            public bool ToggleStarOn(int id) => SetStarState(id, true);

            [System.Web.Http.Route("{id}/Star")]
            [System.Web.Http.HttpPut]
            public bool ToggleStarOff(int id) => SetStarState(id, false);
        }
}