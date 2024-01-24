
using ViewModels.ViewModels;

namespace Business_Layer.Rules.ProposalManager
{
    public interface IProposalManager
    {
        Task Add(ProposalViewModel model);
    }
}