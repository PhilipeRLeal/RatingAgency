using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Data.DataBase.Identity
{
    
    public class CustomIdentityRole: IdentityRole<int>
    {
        
        public CustomIdentityRole() : base()
        {
            
        }


    }


    public static class CustomIdentityRoleFactory
    {

        public static CustomIdentityRole Master = new CustomIdentityRole{Name = "Master" };

        public static CustomIdentityRole Admin = new CustomIdentityRole{Name = "Admin" };

        public static CustomIdentityRole Manager = new CustomIdentityRole{Name = "Manager" };

        public static CustomIdentityRole User = new CustomIdentityRole { Name = "User" };

        public static CustomIdentityRole Client = new CustomIdentityRole{Name = "Client" };

        public static CustomIdentityRole Default = new CustomIdentityRole { Name = "Default" };

        public static CustomIdentityRole Member = new CustomIdentityRole { Name = "Member" };

        public static CustomIdentityRole Visit = new CustomIdentityRole { Name = "Visit"};

        public static CustomIdentityRole Uknown = new CustomIdentityRole { Name = "Uknown" };


        public static IEnumerable<CustomIdentityRole> Generate()
        {
            return new CustomIdentityRole[] {Master, Admin, Manager, User, Client, Default, Member, Visit, Uknown};     
        }
    }
}
