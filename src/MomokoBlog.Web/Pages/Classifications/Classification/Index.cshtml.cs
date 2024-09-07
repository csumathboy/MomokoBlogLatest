using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace MomokoBlog.Web.Pages.Classifications.Classification;

public class IndexModel : MomokoBlogPageModel
{
    public ClassificationFilterInput ClassificationFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class ClassificationFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ClassificationName")]
    public string? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ClassificationDescription")]
    public string? Description { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ClassificationNickName")]
    public string? NickName { get; set; }

   
}
