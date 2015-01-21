using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using DataService.MongoDB.Services;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace DataService.MongoDB.Concrete
{
    public class MongoDbRepository<T> : IMongoDbRepository<T>, IDisposable where T : EntityBase
    {
        private MongoDatabase _database;
        private MongoCollection<T> _collection;

        public MongoDbRepository()
        {
            GetDatabase();
            GetCollection();
        }

        public bool Insert(T entity)
        {
            entity.Id = Guid.NewGuid();
            return _collection.Insert(entity).Ok;
        }

        public bool Update(T entity)
        {
            return _collection
                .Save(entity)
                .DocumentsAffected > 0;
        }

        public bool Delete(T entity)
        {
            return _collection
                .Remove(Query.EQ("_id", entity.Id))
                .DocumentsAffected > 0;
        }

        public IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return _collection
                .AsQueryable()
                .Where(predicate.Compile())
                .ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _collection.FindAllAs<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _collection.FindOneByIdAs<T>(id);
        }

        private void GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());
            var server = client.GetServer();

            _database = server.GetDatabase(GetDatabaseName());
        }

        private string GetConnectionString()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbConnectionString")
                        .Replace("{DB_NAME}", GetDatabaseName());
        }

        private string GetDatabaseName()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbDatabaseName");
        }

        private void GetCollection()
        {
            _collection = _database
                .GetCollection<T>(typeof(T).Name);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
