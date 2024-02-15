using Data.DataBase.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Data.DataBase.Initializer.appUsers.DefaultTypes
{
    /// <summary>
    /// Class responsible for providing default Roles to the database application
    /// </summary>
    internal sealed class AppDefaultRolesProvider
    {
        public IServiceScope Scope { get; }


        private RoleManager<CustomIdentityRole>? _RoleManager = default;


        private RoleManager<CustomIdentityRole> Manager
        {
            get
            {
                if (_RoleManager == null)
                {
                    this._RoleManager = Scope.ServiceProvider.GetRequiredService<RoleManager<Identity.CustomIdentityRole>>();
                }
                return _RoleManager;
            }
        }


        internal AppDefaultRolesProvider(IServiceScope scope)
        {
            this.Scope = scope;
        }


        internal IEnumerable<CustomIdentityRole> Seed()
        {
            return CustomIdentityRoleFactory.Generate();
        }

        public async Task CreateAsync()
        {
            foreach (CustomIdentityRole role in Seed())
            {
                var exists = await this.Manager.RoleExistsAsync(role.Name);

                if (exists == false)
                {
                    await this.Manager.CreateAsync(role);
                }
            }

            this.Manager.Dispose();
        }
    }
}
