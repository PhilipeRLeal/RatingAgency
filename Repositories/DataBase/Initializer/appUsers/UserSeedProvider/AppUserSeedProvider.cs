using Data.DataBase.Identity;
using Data.DbContexts.AppDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Data.DataBase.Initializer.appUsers.UserSeedProvider
{
    internal sealed class AppUserSeedProvider
    {
        internal IServiceScope Scope { get; }
        public AppDbContext AppContext { get; }
        internal RoleManager<CustomIdentityRole> RoleManager { get; init; }

        internal UserManager<CustomIdentityUser> UserManager { get; init; }
        

        internal AppUserSeedProvider(IServiceScope scope)
        { 
            this.Scope = scope;

            this.AppContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            this.RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<CustomIdentityRole>>();

            this.UserManager = scope.ServiceProvider.GetRequiredService<UserManager<CustomIdentityUser>>();
        }

        private static IEnumerable<CustomIdentityUser> Seed()
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
            foreach(CustomIdentityUser user in Seed())
            {
                CustomIdentityUser? foundUser = await this.UserManager.FindByEmailAsync(user.Email ?? "");
                if (Object.ReferenceEquals(foundUser, null))
                {
                    List<string> userRoles = user.Roles.Where(s => !string.IsNullOrEmpty(s.Name)).Select(r => r.Name).ToList();


                    if (user.Password == null)
                    { 
                        await this.UserManager.CreateAsync(user);
                    }
                    else
                    { 
                        await this.UserManager.CreateAsync(user, user.Password);

                        AppContext.SaveChanges();
                    }
                    if (userRoles.Any())
                    {
                        await this.UserManager.AddToRolesAsync(user, userRoles);

                        AppContext.SaveChanges();
                    }
                }
            }
        }
    }
}
