using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace MomokoBlog.Web.Pages.Comments.Comment;

public class IndexModel : MomokoBlogPageModel
{
    public CommentFilterInput CommentFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class CommentFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CommentTitle")]
    public string? Title { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CommentPostsId")]
    public Guid? PostsId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CommentDescription")]
    public string? Description { get; set; }

    //[FormControlSize(AbpFormControlSize.Small)]
    //[Display(Name = "CommentRealName")]
    //public string? RealName { get; set; }

    //[FormControlSize(AbpFormControlSize.Small)]
    //[Display(Name = "CommentEmail")]
    //public string? Email { get; set; }

    //[FormControlSize(AbpFormControlSize.Small)]
    //[Display(Name = "CommentPhoneNumber")]
    //public string? PhoneNumber { get; set; }
}
