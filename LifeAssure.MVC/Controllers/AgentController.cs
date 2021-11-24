using LifeAssure.Data;
using LifeAssure.Models;
using LifeAssure.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeAssure.MVC.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        // GET: Agent
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AgentService(userId);
            var model = service.GetAgents();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAgentService();

            if (service.CreateAgent(model))
            {
                TempData["SaveResult"] = "Your agent was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Agent could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAgentService();
            var model = svc.GetAgentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAgentService();
            var detail = service.GetAgentById(id);
            var model =
                new AgentEdit
                {
                    AgentId = detail.AgentId,
                    Name = detail.Name,
                    LengthOfEmployment = detail.LengthOfEmployment
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AgentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.AgentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAgentService();

            if (service.UpdateAgent(model))
            {
                TempData["SaveResult"] = "Your agent was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your agent could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAgentService();
            var model = svc.GetAgentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAgent(int id)
        {
            var service = CreateAgentService();
            service.DeleteAgent(id);
            TempData["SaveResult"] = "Your agent was deleted";
            return RedirectToAction("Index");
        }

        private AgentService CreateAgentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AgentService(userId);
            return service;
        }

    }
}