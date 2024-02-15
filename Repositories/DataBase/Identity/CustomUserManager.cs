using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase.Identity
{
    public class CustomUserManager : UserManager<CustomIdentityUser>
    {
        public CustomUserManager(IUserStore<CustomIdentityUser> store,
                                 IOptions<IdentityOptions> optionsAccessor,
                                 IPasswordHasher<CustomIdentityUser> passwordHasher,
                                 IEnumerable<IUserValidator<CustomIdentityUser>> userValidators,
                                 IEnumerable<IPasswordValidator<CustomIdentityUser>> passwordValidators,
                                 ILookupNormalizer keyNormalizer,
                                 IdentityErrorDescriber errors,
                                 IServiceProvider services,
                                 ILogger<CustomUserManager> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}
