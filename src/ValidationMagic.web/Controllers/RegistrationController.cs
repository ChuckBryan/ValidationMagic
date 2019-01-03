namespace ValidationMagic.web.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.RegistrationModel;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class RegistrationController : Controller
    {
        private readonly AppDbContext _dbContext;

        public RegistrationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.HowHeardOptions = new List<SelectListItem>
            {
                new SelectListItem("Online", "Online"),
                new SelectListItem("Radio", "Radio"),
                new SelectListItem("News", "News"),
                new SelectListItem("Other", "Other"),
            };

            return View();
        }

        public IActionResult SaveRegistration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                // Note: Because we have posted to the Save Registrations,
                // These List Items are no longer loaded.
                ViewBag.HowHeardOptions = new List<SelectListItem>
                {
                    new SelectListItem("Online", "Online"),
                    new SelectListItem("Radio", "Radio"),
                    new SelectListItem("News", "News"),
                    new SelectListItem("Other", "Other"),
                };

                return View("Index", model);
            }

            _dbContext.Add(new Registration
            {
                Email = model.Email,
                HowDidYouHear = model.HowHeard,
                HowDidYouHearOther = model.HowHeardOther
            });

            _dbContext.SaveChanges();

            // Save Data
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult ValidateUniqueName(string email)
        {
            var exists = _dbContext.Registrations.Any(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            return Json(!exists ? "true" : $"An account for address {email} already exists");

        }
    }
}