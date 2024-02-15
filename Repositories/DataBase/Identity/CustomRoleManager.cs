using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase.Identity
{
    public class CustomRoleManager : RoleManager<CustomIdentityRole>
    {
        public CustomRoleManager(IRoleStore<CustomIdentityRole> store,
                                 IEnumerable<IRoleValidator<CustomIdentityRole>> roleValidators,
                                 ILookupNormalizer keyNormalizer,
                                 IdentityErrorDescriber errors,
                                 ILogger<RoleManager<CustomIdentityRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
