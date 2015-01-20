using System;
using DataService.MongoDB.Concrete;

namespace DataService.MongoDB.Services
{
    public interface IMongoDbPersistenceService: IDisposable
    {
         MongoDbRepository<T> GetMongoDbRepository<T>() where T : EntityBase;
    }
    
}
