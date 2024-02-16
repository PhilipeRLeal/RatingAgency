using Data.DataBase.Identity;
using Data.DataBase.Identity.Factories;
using Data.DbContexts.AppDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.DataBase.Initializer.appUsers.UserSeedProvider
{
    internal sealed class AppUserSeedProvider
    {
        public IPasswordHasher<IdentityUser> PassWordHasher { get; } = new PasswordHasher<IdentityUser>();
        internal IServiceScope Scope { get; }
        public AppDbContext AppContext { get; }
        internal RoleManager<IdentityRole> RoleManager { get; init; }

        internal UserManager<IdentityUser> UserManager { get; init; }
        

        internal AppUserSeedProvider(IServiceScope scope)
        {
            this.Scope = scope;

            this.AppContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            this.RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            this.UserManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        }

        private static IEnumerable<IdentityUserRoles> Seed()
        {
            return IdentityUserFactory.Generate();
        }

        /// <summary>
        /// Creates all Default users of this application:
        ///     1 user of type master
        ///     1 user of type manager
        /// </summary>
        /// <returns></returns>
        public async Task CreateAsync()
        {
            foreach(IdentityUserRoles userRoles in Seed())
            {
                IdentityUser? foundUser = await this.UserManager.FindByEmailAsync(userRoles.User.Email ?? "");
                if (Object.ReferenceEquals(foundUser, null))
                {
                    
                    if (userRoles.User.PasswordHash == null)
                    { 
                        await this.UserManager.CreateAsync(userRoles.User);
                    }
                    else
                    {
                        var hashPassword = this.PassWordHasher.HashPassword(userRoles.User, userRoles.User.PasswordHash);
                        userRoles.User.PasswordHash = hashPassword;

                        var userStore = new UserStore<IdentityUser>(this.AppContext);
                        var result = userStore.CreateAsync(userRoles.User);

                        // await this.UserManager.CreateAsync(user, hashPassword);

                        AppContext.SaveChanges();

                        AssignRoles(userRoles.User.Email, userRoles.Roles);
                    }
                }
            }
        }

        public async Task<IdentityResult> AssignRoles(string email, IEnumerable<IdentityRole> roles)
        {
            UserManager<IdentityUser> _userManager = this.Scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles.Select(r => r.Name).ToList());

            return result;
        }
    }
}
