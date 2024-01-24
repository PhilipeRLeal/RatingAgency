using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace RatingAgency.Validators.ControllerValidators
{
    public class ModelStateValidatorConvension : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controllerModel in application.Controllers)
            {
                controllerModel.Filters.Add(new ValidateModelAttribute());
            }
        }
    }
}
