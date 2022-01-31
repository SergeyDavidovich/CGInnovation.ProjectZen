using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CGInnovation.ProjectZen.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class ProjectZenBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ZEN Project";
    }
}
