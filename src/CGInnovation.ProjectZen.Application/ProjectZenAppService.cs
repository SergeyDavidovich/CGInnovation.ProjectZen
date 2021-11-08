using System;
using System.Collections.Generic;
using System.Text;
using CGInnovation.ProjectZen.Localization;
using Volo.Abp.Application.Services;

namespace CGInnovation.ProjectZen
{
    /* Inherit your application services from this class.
     */
    public abstract class ProjectZenAppService : ApplicationService
    {
        protected ProjectZenAppService()
        {
            LocalizationResource = typeof(ProjectZenResource);
        }
    }
}
