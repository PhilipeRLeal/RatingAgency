using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataBase.Identity
{
    [Table("AspNetUsers")]
    [Index(nameof(UserName), nameof(Email), IsUnique = true)]
    public class CustomIdentityUser: IdentityUser<int>
    {

        #region Properties
        [NotMapped]
        internal string? Password { get; set; }

        

        [NotMapped]
        public IEnumerable<CustomIdentityRole> Roles { get; set; }


        #endregion Properties

        public CustomIdentityUser() { }

    }

    public class IdentityUserFactory
    {
        public static IEnumerable<CustomIdentityUser> Generate()
        {
            var Master = new CustomIdentityUser
            {
                
                UserName = "Master",
                Password = "Master@master123",
                Email = "master@app.com",
                EmailConfirmed = true,
                Roles = new []{ CustomIdentityRoleFactory.Master },
                SecurityStamp = Guid.NewGuid().ToString() 
            };

            var Adminstrator = new CustomIdentityUser
            {
                
                UserName = "Adminstrator",
                Password = "Admin@master123",
                Email = "admin@app.com",
                EmailConfirmed = true,
                Roles = new []{ CustomIdentityRoleFactory.Admin },
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var Default = new CustomIdentityUser
            {
                
                UserName = "Default",
                Email = "default@app.com",
                EmailConfirmed = true,
                Roles = new []{ CustomIdentityRoleFactory.Default },
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var Client = new CustomIdentityUser
            {
                
                UserName = "Client",
                Email = "defaultclient@app.com",
                EmailConfirmed = true,
                Roles = new []{ CustomIdentityRoleFactory.Client },
                SecurityStamp = Guid.NewGuid().ToString()
            };

            return new[] { Master, Adminstrator, Default, Client };

    }
}
}
