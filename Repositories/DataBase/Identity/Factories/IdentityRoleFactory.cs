using Microsoft.AspNetCore.Identity;

namespace Data.DataBase.Identity.Factories
{



    public static class IdentityRoleFactory
    {

        public static IdentityRole Master = new IdentityRole { Name = "Master" };

        public static IdentityRole Admin = new IdentityRole { Name = "Admin" };

        public static IdentityRole Manager = new IdentityRole { Name = "Manager" };

        public static IdentityRole User = new IdentityRole { Name = "User" };

        public static IdentityRole Client = new IdentityRole { Name = "Client" };

        public static IdentityRole Default = new IdentityRole { Name = "Default" };

        public static IdentityRole Member = new IdentityRole { Name = "Member" };

        public static IdentityRole Visit = new IdentityRole { Name = "Visit" };

        public static IdentityRole Uknown = new IdentityRole { Name = "Uknown" };


        public static IEnumerable<IdentityRole> Generate()
        {
            return new IdentityRole[] { Master, Admin, Manager, User, Client, Default, Member, Visit, Uknown };
        }
    }
}
