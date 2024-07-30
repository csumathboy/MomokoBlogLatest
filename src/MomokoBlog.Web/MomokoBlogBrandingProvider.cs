using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MomokoBlog.Web;

[Dependency(ReplaceServices = true)]
public class MomokoBlogBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MomokoBlog";
}
