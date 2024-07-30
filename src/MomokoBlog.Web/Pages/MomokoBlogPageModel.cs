using MomokoBlog.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MomokoBlog.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MomokoBlogPageModel : AbpPageModel
{
    protected MomokoBlogPageModel()
    {
        LocalizationResourceType = typeof(MomokoBlogResource);
    }
}
