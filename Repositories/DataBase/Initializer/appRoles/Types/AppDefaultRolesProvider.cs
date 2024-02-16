using Data.DataBase.Identity.Factories;
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


        private RoleManager<IdentityRole>? _RoleManager = default;


        private RoleManager<IdentityRole> Manager
        {
            get
            {
                if (_RoleManager == null)
                {
                    this._RoleManager = Scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                }
                return _RoleManager;
            }
        }


        internal AppDefaultRolesProvider(IServiceScope scope)
        {
            this.Scope = scope;
        }


        internal IEnumerable<IdentityRole> Seed()
        {
            return IdentityRoleFactory.Generate();
        }

        public async Task CreateAsync()
        {
            foreach (IdentityRole role in Seed())
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
