using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Core.Infrastructure.Providers
{
    public class RoleStore<T> : IRoleStore<T>, IQueryableRoleStore<T>
           where T : IdentityRole
    {
        private readonly IdentityContext _context;

        public RoleStore(IdentityContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> Roles
        {
            get { return _context.Roles.AsQueryable<T>(); }
        }

        public virtual void Dispose()
        {
        }

        public virtual System.Threading.Tasks.Task CreateAsync(T role)
        {
            return System.Threading.Tasks.Task.Run(() => _context.Roles.Insert(role));
        }

        public virtual System.Threading.Tasks.Task UpdateAsync(T role)
        {
            return System.Threading.Tasks.Task.Run(() => _context.Roles.Save(role));
        }

        public virtual System.Threading.Tasks.Task DeleteAsync(T role)
        {
            var queryById = Query<T>.EQ(r => r.Id, role.Id);
            return System.Threading.Tasks.Task.Run(() => _context.Roles.Remove(queryById));
        }

        public virtual Task<T> FindByIdAsync(string roleId)
        {
            return System.Threading.Tasks.Task.Run(() => _context.Roles.FindOneByIdAs<T>(ObjectId.Parse(roleId)));
        }

        public virtual Task<T> FindByNameAsync(string roleName)
        {
            var queryByName = Query<T>.EQ(r => r.Name, roleName);
            return System.Threading.Tasks.Task.Run(() => _context.Roles.FindOneAs<T>(queryByName));
        }
    }
}
