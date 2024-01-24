using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.ViewModels
{
    public class ProposalViewModel
    {
        [Display(Name = "Proposal File")]
        [Required(ErrorMessage = "Please enter a Proposal File")]
        [FileExtensionsValidator(ErrorMessage ="invalid File Format. Please Provide a Json file", 
            Extensions = "json")]
        public IFormFile File { get; set; }

        [Display(Name="Client's Name")]
        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }    

        private DateTime DateTime { get; set; } = DateTime.Now;
    }
}
