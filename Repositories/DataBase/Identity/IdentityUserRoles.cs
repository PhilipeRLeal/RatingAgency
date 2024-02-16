using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase.Identity
{
    public class IdentityUserRoles
    {
        public IdentityUserRoles(IdentityUser user, IEnumerable<IdentityRole> roles)
        {
            User = user;
            Roles = roles;
        }

        public IdentityUser User { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }

    }
}
