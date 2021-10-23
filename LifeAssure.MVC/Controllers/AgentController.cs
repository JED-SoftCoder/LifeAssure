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

        private AgentService CreateAgentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AgentService(userId);
            return service;
        }

    }
}