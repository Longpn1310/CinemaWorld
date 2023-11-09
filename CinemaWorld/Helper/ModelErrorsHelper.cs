using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinemaWorld.Helper
{
    public static class ModelErrorsHelper
    {
        public static string GetModelErrors(ModelStateDictionary modelState)
        {
            return string.Join(Environment.NewLine, modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
        }
    }
}
