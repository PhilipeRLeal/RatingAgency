using Business_Layer.Rules.Rating.Factory;
using Data.Entities;
using Repositories.DbContexts.GenericDbContext;
using Repositories.Repositories;
using System.Text.Json;
using ViewModels.ViewModels;

namespace Business_Layer.Rules.ProposalManager
{
    public class ProposalManager : IProposalManager
    {

        private RatingRepository Repository;

        public ProposalManager(AppDbContext context)
        {
            Repository = new RatingRepository(context);
        }

        public async Task Add(ProposalViewModel model)
        {
            var proposal = await DeSerialize(model);

            
            if (proposal != null)
            {
                proposal = EvaluateRatingFromProposal(proposal);

                await Repository.Upsert(proposal.Rating);
            }

        }

        private Proposal EvaluateRatingFromProposal(Proposal proposal)
        {
            var factory = new RatingFactory();

            proposal = factory.Evaluate(proposal);

            return proposal;


        }

        private static async Task<Proposal?> DeSerialize(ProposalViewModel model)
        {
            Stream stream = model.File.OpenReadStream();
            var proposal = await JsonSerializer.DeserializeAsync<Proposal>(stream);

            return proposal;
        }
    }
}
