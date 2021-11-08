using CGInnovation.ProjectZen.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CGInnovation.ProjectZen.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ProjectZenController : AbpController
    {
        protected ProjectZenController()
        {
            LocalizationResource = typeof(ProjectZenResource);
        }
    }
}