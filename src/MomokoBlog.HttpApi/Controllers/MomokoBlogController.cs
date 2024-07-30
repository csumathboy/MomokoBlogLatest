using MomokoBlog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MomokoBlog.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MomokoBlogController : AbpControllerBase
{
    protected MomokoBlogController()
    {
        LocalizationResource = typeof(MomokoBlogResource);
    }
}
