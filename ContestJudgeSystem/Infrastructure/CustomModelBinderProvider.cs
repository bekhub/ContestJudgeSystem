using ContestJudgeSystem.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContestJudgeSystem.Infrastructure
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _binder = new CustomModelBinder();

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(SubmissionModel.Add) ? _binder : null;
        }
    }
}
