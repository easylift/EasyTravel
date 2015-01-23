

using Common.Concrete;
using Common.Services;
using DataService.MongoDB.Concrete;
using DataService.MongoDB.Services;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace EasyLift.Registries
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                   scan.AddAllTypesOf(typeof (IMongoDbRepository<>));
                });
           ;
            For<IMongoDbPersistenceService>().Use<MongoDbPersistenceService>();
            For<IIndividualRegistration>().Use<IndividualRegistration>().Ctor<MongoDbPersistenceService>();
        }

    }
}