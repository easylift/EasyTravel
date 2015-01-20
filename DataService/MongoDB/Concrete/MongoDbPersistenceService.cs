using System;
using DataService.MongoDB.Services;

namespace DataService.MongoDB.Concrete
{
    public class MongoDbPersistenceService : IMongoDbPersistenceService
    {
        public MongoDbRepository<T> GetMongoDbRepository<T>() where T : EntityBase
        {
            return new MongoDbRepository<T>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
