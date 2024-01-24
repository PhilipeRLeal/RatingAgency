using Business_Layer.Rules.ProposalManager;
using Microsoft.AspNetCore.Mvc;
using RatingAgency.Responses;
using ViewModels.ViewModels;

namespace RatingAgency.Controllers
{
    
    public class ProposalController : Controller
    {

        #region Properties
        public IProposalManager ProposalManager { get; set; }

        #endregion Properties

        #region Constructor

        public ProposalController(IProposalManager manager)
        {
            ProposalManager = manager;
        }

        #endregion Constructor

        public IActionResult Index()
        {
            return View();
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
