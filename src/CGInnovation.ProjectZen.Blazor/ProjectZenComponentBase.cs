using CGInnovation.ProjectZen.Localization;
using Volo.Abp.AspNetCore.Components;

namespace CGInnovation.ProjectZen.Blazor
{
    public abstract class ProjectZenComponentBase : AbpComponentBase
    {
        protected ProjectZenComponentBase()
        {
            LocalizationResource = typeof(ProjectZenResource);
        }
    }
}
