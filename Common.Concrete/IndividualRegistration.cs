using System.Collections.Generic;
using System.Linq;
using Common.Services;
using DataService.MongoDB.Services;
using Domain.Model;

namespace Common.Concrete
{
    public class IndividualRegistration : IIndividualRegistration
    {
        private readonly IMongoDbPersistenceService _service;

        public IndividualRegistration(IMongoDbPersistenceService service)
        {
            _service = service;
        }

        public IEnumerable<Individual> GetAllIndividuals()
        {
            using (var repository = _service.GetMongoDbRepository<Individual>())
            {
                return repository.GetAll();
            }
        }

        public Individual GetIndividualByReference(string individualRef)
        {
            using (var repository = _service.GetMongoDbRepository<Individual>())
            {
                return repository.SearchFor(x => x.IndividualRef == individualRef).FirstOrDefault();
            }
        }
    }
}
