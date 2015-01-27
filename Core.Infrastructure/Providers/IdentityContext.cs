using MongoDB.Driver;

namespace Core.Infrastructure.Providers
{
    public class IdentityContext
    {
        public MongoCollection Users { get; set; }
        public MongoCollection Roles { get; set; }

        public IdentityContext()
        {
        
        }

        public IdentityContext(MongoCollection users)
        {
            Users = users;
        }

        public IdentityContext(MongoCollection users, MongoCollection roles):this(users)
        {
            Roles = roles;
        }
    }
}