using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace MomokoBlog.Web.Pages.Tags.Tag;

public class IndexModel : MomokoBlogPageModel
{
    public TagFilterInput TagFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class TagFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagName")]
    public string? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagNickName")]
    public string? NickName { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TagArtCount")]
    public int? ArtCount { get; set; }
}
