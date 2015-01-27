using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Core.Infrastructure.Providers
{
    public class IndexChecks
    {
        public static void EnsureUniqueIndexOnUserName(MongoCollection users)
        {
            var userName = new IndexKeysBuilder<IdentityUser>().Ascending(t => t.UserName);
            var unique = new IndexOptionsBuilder().SetUnique(true);
            users.EnsureIndex(userName, unique);
        }

        public static void EnsureUniqueIndexOnRoleName(MongoCollection roles)
        {
            var roleName = new IndexKeysBuilder<IdentityRole>().Ascending(t => t.Name);
            var unique = new IndexOptionsBuilder().SetUnique(true);
            roles.EnsureIndex(roleName, unique);
        }

        public static void EnsureUniqueIndexOnEmail(MongoCollection users)
        {
            var email = new IndexKeysBuilder<IdentityUser>().Ascending(t => t.Email);
            var unique = new IndexOptionsBuilder().SetUnique(true);
            users.EnsureIndex(email, unique);
        }
    }
}
