using System;
using System.Configuration;
using Core.Infrastructure.Providers;
using MongoDB.Driver;

namespace EasyLift.Models
{
    public class ApplicationMongoContext : IdentityContext,IDisposable
    {
        public ApplicationMongoContext(MongoCollection users, MongoCollection role)
            : base(users,role)
        {
        }

        public static ApplicationMongoContext Create()
        {
            var database = GetDatabase();
            var users = database.GetCollection<IdentityUser>("users");
            var roles = database.GetCollection<IdentityRole>("roles");
            return new ApplicationMongoContext(users, roles);
        }
        
        private static MongoDatabase GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());
            var server = client.GetServer();

            return server.GetDatabase(GetDatabaseName());
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager
                .AppSettings
                .Get("MongoDbConnectionString")
                .Replace("{DB_NAME}", GetDatabaseName());
        }

        private static string GetDatabaseName()
        {
            return ConfigurationManager
                .AppSettings
                .Get("MongoDbDatabaseName");
        }

        public void Dispose()
        {
        }
    }
}