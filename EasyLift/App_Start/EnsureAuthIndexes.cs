using Core.Infrastructure.Providers;
using EasyLift.Models;

namespace EasyLift
{
    public class EnsureAuthIndexes
    {
        public static void Exist()
        {
            var context = ApplicationMongoContext.Create();
            IndexChecks.EnsureUniqueIndexOnUserName(context.Users);
            IndexChecks.EnsureUniqueIndexOnRoleName(context.Roles);
        }
    }
}