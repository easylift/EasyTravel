using System.Linq;
using System.Web.Http;
using Common.Services;
using Domain.Model;

namespace EasyLift.Areas.API.Controllers
{
    public class IndividualController : ApiController
    {
        private readonly IIndividualRegistration _registration;

        public IndividualController(IIndividualRegistration registration )
        {
            _registration = registration;
        }

        public IHttpActionResult Get()
        {
            var result= _registration.GetAllIndividuals().ToList();
            return result.Count > 0 ? (IHttpActionResult) Ok(result) : NotFound();
        }

        public IHttpActionResult Get(string individualRef)
        {
            var result =_registration.GetIndividualByReference(individualRef);
            return result != null ? (IHttpActionResult) Ok(result) : NotFound();
        }

        public void Post([FromBody]Individual value)
        {
        }

        public void Put(int id, [FromBody]Individual value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
