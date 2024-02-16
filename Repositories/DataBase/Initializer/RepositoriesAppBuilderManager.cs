using Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase.Initializer
{
    public class RepositoriesAppBuilderManager
    {

        public static void AddRepositories(WebApplicationBuilder builder) { 
            builder.Services.AddScoped<IRepository<Insurance>, InsuranceRepository>();
            builder.Services.AddScoped<IRepository<Rating>, RatingRepository>();
            builder.Services.AddScoped<RateEnumType, RateEnumType>();

        }
    }
}
