using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Common.Services;
using Domain.Model;

namespace EasyLift.Controllers
{
    public class RegistrationController :Controller
    {
        private readonly IIndividualRegistration _registration;

        public RegistrationController(IIndividualRegistration registration)
        {
            _registration = registration;
        }

        public ActionResult Index()
   {
            var result= _registration.GetAllIndividuals().ToList();
            return result.Count > 0 ? View(result) : View(new List<Individual>());
        }

     
        public ActionResult AddMember()
        {
            var model= new Individual();
            return View(model);
        }

           [HttpPost]
        public ActionResult CreateMember(Individual model)
        {
            var result = _registration.SaveIndividual(model);
            return RedirectToAction("Individual");
        }

        
    }
}
