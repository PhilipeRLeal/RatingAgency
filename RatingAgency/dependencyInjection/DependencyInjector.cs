using Business_Layer.Rules.ProposalManager;
using Data.DataBase.Identity;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Core.Types;
using Repositories.Repositories;
using ViewModels.ViewModels;

namespace RatingAgency.dependencyInjection
{
    public static class DependencyInjector
    {
        public static WebApplicationBuilder Inject(WebApplicationBuilder builder)
        {

            InjectRepositories(builder);

            InjectBusinessLayerTypes(builder);

            InjectLoger(builder);

            return builder;
        }


        private static void InjectBusinessLayerTypes(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ProposalViewModel, ProposalViewModel>(); 
            builder.Services.AddScoped<IProposalManager, ProposalManager>();
        }

        private static void InjectLoger(WebApplicationBuilder builder)
        {
            
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
        }

        private static void InjectRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepository<Proposal>, ProposalRepository>();
            builder.Services.AddScoped<IRepository<Insurance>, InsuranceRepository>();
            builder.Services.AddScoped<IRepository<Rating>, RatingRepository>();
        }
    }
}
