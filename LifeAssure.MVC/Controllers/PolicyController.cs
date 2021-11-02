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

            if (service.CreatePolicy(model))
            {
                TempData["SaveResult"] = "Your policy was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Policy could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePolicyService();
            var model = svc.GetPolicyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePolicyService();
            var detail = service.GetPolicyById(id);
            var model =
                new PolicyEdit
                {
                    AgentId = detail.AgentId,
                    CustomerId = detail.CustomerId,
                    TypeOfPolicy = detail.TypeOfPolicy,
                    PolicyAmount = detail.PolicyAmount,
                    Details = detail.Details,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PolicyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PolicyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePolicyService();

            if (service.UpdatePolicy(model))
            {
                TempData["SaveResult"] = "Your policy was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your policy could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePolicyService();
            var model = svc.GetPolicyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePolicy(int id)
        {
            var service = CreatePolicyService();
            service.DeletePolicy(id);
            TempData["SaveResult"] = "Your policy was deleted";
            return RedirectToAction("Index");
        }

        private PolicyService CreatePolicyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PolicyService(userId);
            return service;
        }
    }
}