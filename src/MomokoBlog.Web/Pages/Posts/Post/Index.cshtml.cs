using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using MomokoBlog.Posts;

namespace MomokoBlog.Web.Pages.Posts.Post;

public class IndexModel : MomokoBlogPageModel
{
    public PostFilterInput PostFilter { get; set; }
     
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class PostFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostTitle")]
    public string? Title { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostDescription")]
    public string? Description { get; set; }
 
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostPostsStatus")]
    public PostStatus? PostsStatus { get; set; }
}
