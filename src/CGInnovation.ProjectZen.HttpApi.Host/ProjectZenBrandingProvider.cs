using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CGInnovation.ProjectZen
{
    [Dependency(ReplaceServices = true)]
    public class ProjectZenBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ProjectZen";
    }
}
