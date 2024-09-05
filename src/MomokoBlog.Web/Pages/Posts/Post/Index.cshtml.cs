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
    [Display(Name = "PostAuthor")]
    public string? Author { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostDescription")]
    public string? Description { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostClassId")]
    public Guid? ClassId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostContextValue")]
    public string? ContextValue { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostPicture")]
    public string? Picture { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostSort")]
    public int? Sort { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostIsTop")]
    public bool? IsTop { get; set; }

 
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "PostPostsStatus")]
    public PostStatus? PostsStatus { get; set; }
}
