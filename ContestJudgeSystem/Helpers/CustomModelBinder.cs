using System;
using System.Threading.Tasks;
using ContestJudgeSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContestJudgeSystem.Helpers
{
    public class CustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var form = bindingContext.HttpContext.Request.Form;

            var result = new SubmissionModel
            {
                LanguageId = Convert.ToInt32(form["languageId"]),
                SourceCode = form["sourceCode"],
                Inputs = form.Files.GetFiles("inputs"),
                Outputs = form.Files.GetFiles("outputs"),
            };
            
            bindingContext.Result = ModelBindingResult.Success(result);
            
            return Task.CompletedTask;
        }
    }
}
