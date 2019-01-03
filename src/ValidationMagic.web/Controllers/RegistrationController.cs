namespace ValidationMagic.web.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.RegistrationModel;
    using System.Collections.Generic;

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
            _dbContext.Add(new Registration
            {
                Email = model.Email,
                HowDidYouHear = model.HowHeard,
                HowDidYouHearOther = model.HowHeardOther
            });

            _dbContext.SaveChanges();

            // Save Data
            // return RedirectToAction("ThankYou");
            return Json(new { Redirect = Url.Action("ThankYou") });
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}