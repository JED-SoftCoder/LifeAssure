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
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PolicyService(userId);
            var model = service.GetPolicies();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PolicyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePolicyService();

            service.CreatePolicy(model);

            if (service.CreatePolicy(model))
            {
                TempData["SaveResult"] = "Your policy was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Policy could not be created.");

            return View(model);
        }

        private PolicyService CreatePolicyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PolicyService(userId);
            return service;
        }
    }
}