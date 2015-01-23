using System.Linq;
using System.Web.Http;
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

        public ActionResult Individual()
        {
            var result= _registration.GetAllIndividuals().ToList();
            return result.Count > 0 ? View(result) : null;
        }

        
    }
}
