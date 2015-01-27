using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Core.Infrastructure.Providers
{
    public class UserStore<T> : IUserStore<T>, IUserPasswordStore<T>,
        IUserRoleStore<T>,
        IUserLoginStore<T>,
        IUserSecurityStampStore<T>,
        IUserEmailStore<T>,
        IUserClaimStore<T>,
        IQueryableUserStore<T>,
        IUserPhoneNumberStore<T>,
        IUserTwoFactorStore<T, string>,
        IUserLockoutStore<T, string>
        where T : IdentityUser, IUser<string>
    {

        private readonly IdentityContext _context;

        public UserStore(IdentityContext context)
        {
            _context = context;
        }

        public virtual void Dispose()
        {
        }

        public virtual System.Threading.Tasks.Task CreateAsync(T user)
        {
            return System.Threading.Tasks.Task.Run(() => _context.Users.Insert(user));
        }

        public virtual System.Threading.Tasks.Task UpdateAsync(T user)
        {
            return System.Threading.Tasks.Task.Run(() => _context.Users.Save(user));
        }

        public virtual System.Threading.Tasks.Task DeleteAsync(T user)
        {
            var queryById = Query<T>.EQ(u => u.Id, user.Id);
            return System.Threading.Tasks.Task.Run(() => _context.Users.Remove(queryById));
        }

        public virtual Task<T> FindByIdAsync(string userId)
        {
            return System.Threading.Tasks.Task.Run(() => _context.Users.FindOneByIdAs<T>(ObjectId.Parse(userId)));
        }

        public virtual Task<T> FindByNameAsync(string userName)
        {
            var queryByName = Query<T>.EQ(u => u.UserName, userName);
            return System.Threading.Tasks.Task.Run(() => _context.Users.FindOneAs<T>(queryByName));
        }

        public virtual System.Threading.Tasks.Task SetPasswordHashAsync(T user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual Task<string> GetPasswordHashAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.PasswordHash);
        }

        public virtual Task<bool> HasPasswordAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.HasPassword());
        }

        public virtual System.Threading.Tasks.Task AddToRoleAsync(T user, string roleName)
        {
            user.AddRole(roleName);
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual System.Threading.Tasks.Task RemoveFromRoleAsync(T user, string roleName)
        {
            user.RemoveRole(roleName);
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual Task<IList<string>> GetRolesAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult((IList<string>) user.Roles);
        }

        public virtual Task<bool> IsInRoleAsync(T user, string roleName)
        {
            return System.Threading.Tasks.Task.FromResult(user.Roles.Contains(roleName));
        }

        public virtual System.Threading.Tasks.Task AddLoginAsync(T user, UserLoginInfo login)
        {
            user.AddLogin(login);
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual System.Threading.Tasks.Task RemoveLoginAsync(T user, UserLoginInfo login)
        {
            user.RemoveLogin(login);
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual Task<IList<UserLoginInfo>> GetLoginsAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult((IList<UserLoginInfo>) user.Logins);
        }

        public virtual Task<T> FindAsync(UserLoginInfo login)
        {
            return System.Threading.Tasks.Task.Factory
                .StartNew(() => _context.Users.AsQueryable<T>()
                    .FirstOrDefault(u => u.Logins
                        .Any(l => l.LoginProvider == login.LoginProvider && l.ProviderKey == login.ProviderKey)));
        }

        public virtual System.Threading.Tasks.Task SetSecurityStampAsync(T user, string stamp)
        {
            user.SecurityStamp = stamp;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual Task<string> GetSecurityStampAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.SecurityStamp);
        }

        public virtual Task<bool> GetEmailConfirmedAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.EmailConfirmed);
        }

        public virtual System.Threading.Tasks.Task SetEmailConfirmedAsync(T user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual System.Threading.Tasks.Task SetEmailAsync(T user, string email)
        {
            user.Email = email;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual Task<string> GetEmailAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.Email);
        }

        public virtual Task<T> FindByEmailAsync(string email)
        {
            return System.Threading.Tasks.Task.Run(() => _context.Users.AsQueryable<T>().FirstOrDefault(u => u.Email == email));
        }

        public virtual Task<IList<Claim>> GetClaimsAsync(T user)
        {
            return
                System.Threading.Tasks.Task.FromResult(
                    (IList<Claim>) user.Claims.Select(c => c.ToSecurityClaim()).ToList());
        }

        public virtual System.Threading.Tasks.Task AddClaimAsync(T user, Claim claim)
        {
            user.AddClaim(claim);
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual System.Threading.Tasks.Task RemoveClaimAsync(T user, Claim claim)
        {
            user.RemoveClaim(claim);
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual IQueryable<T> Users
        {
            get { return _context.Users.AsQueryable<T>(); }
        }

        public virtual System.Threading.Tasks.Task SetPhoneNumberAsync(T user, string phoneNumber)
        {
            user.PhoneNumber = phoneNumber;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual Task<string> GetPhoneNumberAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.PhoneNumber);
        }

        public virtual Task<bool> GetPhoneNumberConfirmedAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.PhoneNumberConfirmed);
        }

        public virtual System.Threading.Tasks.Task SetPhoneNumberConfirmedAsync(T user, bool confirmed)
        {
            user.PhoneNumberConfirmed = confirmed;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual System.Threading.Tasks.Task SetTwoFactorEnabledAsync(T user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual Task<bool> GetTwoFactorEnabledAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.TwoFactorEnabled);
        }

        public virtual Task<DateTimeOffset> GetLockoutEndDateAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.LockoutEndDateUtc ?? new DateTimeOffset());
        }

        public virtual System.Threading.Tasks.Task SetLockoutEndDateAsync(T user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDateUtc = new DateTime(lockoutEnd.Ticks, DateTimeKind.Utc);
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual Task<int> IncrementAccessFailedCountAsync(T user)
        {
            user.AccessFailedCount++;
            return System.Threading.Tasks.Task.FromResult(user.AccessFailedCount);
        }

        public virtual System.Threading.Tasks.Task ResetAccessFailedCountAsync(T user)
        {
            user.AccessFailedCount = 0;
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public virtual Task<int> GetAccessFailedCountAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.AccessFailedCount);
        }

        public virtual Task<bool> GetLockoutEnabledAsync(T user)
        {
            return System.Threading.Tasks.Task.FromResult(user.LockoutEnabled);
        }

        public virtual System.Threading.Tasks.Task SetLockoutEnabledAsync(T user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            return System.Threading.Tasks.Task.FromResult(0);
        }

    }
}