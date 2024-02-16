using Business_Layer.Rules.ProposalManager;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RatingAgency.Responses;
using ViewModels.ViewModels;

namespace RatingAgency.Controllers
{
    [Authorize]
    public class ProposalController : Controller
    {

        #region Properties
        public IProposalManager ProposalManager { get; set; }
        public ProposalRepository ProposalRepository { get; }

        #endregion Properties

        #region Constructor

        public ProposalController(IProposalManager manager, ProposalRepository proposalRep)
        {
            ProposalManager = manager;

            this.ProposalRepository = proposalRep;
        }

        #endregion Constructor
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? id)
        {

            var proposals = await ProposalRepository.FetchAll();

            return View(new ProposalsPerUserViewModel() { Proposals=proposals});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitProposalForEvaluation(ProposalViewModel model)
        {

            await ProposalManager.Add(model);

            var response = new Response();

            return View(response);
        }
    }
}
