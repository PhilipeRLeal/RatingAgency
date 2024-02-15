using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase.Identity
{
    public class CustomRoleValidator: RoleValidator<CustomIdentityRole>
    {

        public CustomRoleValidator(IdentityErrorDescriber? errors = null): base(errors) { }
    }
}
