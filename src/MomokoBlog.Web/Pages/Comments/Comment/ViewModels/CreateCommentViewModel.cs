using System;
using System.ComponentModel.DataAnnotations;

namespace MomokoBlog.Web.Pages.Comments.Comment.ViewModels;

public class CreateCommentViewModel
{
    [Display(Name = "CommentTitle")]
    public string Title { get; set; }

    [Display(Name = "CommentPostsId")]
    public Guid PostsId { get; set; }

    [Display(Name = "CommentDescription")]
    public string Description { get; set; }

    [Display(Name = "CommentRealName")]
    public string RealName { get; set; }

    [Display(Name = "CommentEmail")]
    public string Email { get; set; }

    [Display(Name = "CommentPhoneNumber")]
    public string PhoneNumber { get; set; }
}
