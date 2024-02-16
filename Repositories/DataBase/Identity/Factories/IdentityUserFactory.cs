using Microsoft.AspNetCore.Identity;

namespace Data.DataBase.Identity.Factories
{

    public class IdentityUserFactory
    {
        public static IdentityUser Master = new IdentityUser
        {

            UserName = "Master",
            PasswordHash = "Master@master123",
            Email = "master@app.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        public static IdentityUser Adminstrator = new IdentityUser
        {

            UserName = "Adminstrator",
            PasswordHash = "Admin@master123",
            Email = "admin@app.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        public static IdentityUser Default = new IdentityUser
        {

            UserName = "Default",
            Email = "default@app.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };


        public static IdentityUser Client = new IdentityUser
        {

            UserName = "Client",
            Email = "defaultclient@app.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };


        public static IEnumerable<IdentityUserRoles> Generate()
        {

            return new[] { IdentityUserRolesFactory.Master,
                IdentityUserRolesFactory.Adminstrator,
                IdentityUserRolesFactory.Default,
                IdentityUserRolesFactory.Client };

        }

        
    }

    public class IdentityUserRolesFactory
    {

        public static IdentityUserRoles Master = new IdentityUserRoles
            (
                IdentityUserFactory.Master,
                new []{IdentityRoleFactory.Master}
            );


        public static IdentityUserRoles Adminstrator = new IdentityUserRoles
            (
                IdentityUserFactory.Adminstrator,
                new []{IdentityRoleFactory.Admin}
            );

        public static IdentityUserRoles Client = new IdentityUserRoles
            (IdentityUserFactory.Client,
             new []{IdentityRoleFactory.Client }
            );

        public static IdentityUserRoles Default = new IdentityUserRoles
            (IdentityUserFactory.Default,
             new []{IdentityRoleFactory.Default }
            );

    }
}
