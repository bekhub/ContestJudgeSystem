using System;
using System.Threading.Tasks;
using ContestJudgeSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models.Enums;

namespace ContestJudgeSystem.Infrastructure
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

            var result = new SubmissionModel.Add
            {
                LanguageId = Convert.ToInt32(form["languageId"]),
                SourceCode = form["sourceCode"],
                Inputs = form.Files.GetFiles("inputs"),
                Outputs = form.Files.GetFiles("outputs"),
                Checker = form["checker"],
                CheckerType = (CheckerEnum) Convert.ToInt32(form["checkerType"]),
            };
            
            bindingContext.Result = ModelBindingResult.Success(result);
            
            return Task.CompletedTask;
        }
    }
}
