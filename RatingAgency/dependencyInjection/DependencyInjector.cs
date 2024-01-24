using Business_Layer.Rules.ProposalManager;
using Microsoft.Extensions.Logging;
using Repositories.Repositories;

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
            builder.Services.AddScoped<IProposalManager, ProposalManager>();
        }

        private static void InjectLoger(WebApplicationBuilder builder)
        {
            
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
        }

        private static void InjectRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<InsuranceRepository, InsuranceRepository>();
            builder.Services.AddScoped<RatingRepository, RatingRepository>();
        }
    }
}
