using ContestJudgeSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContestJudgeSystem.Helpers
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _binder = new CustomModelBinder();
        
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(SubmissionModel) ? _binder : null;
        }
    }
}
