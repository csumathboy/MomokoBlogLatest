using MomokoBlog.Posts;
using System;
using System.ComponentModel.DataAnnotations;

namespace MomokoBlog.Web.Pages.Posts.Post.ViewModels;

public class EditPostViewModel
{
    [Display(Name = "PostTitle")]
    public string Title { get; set; }

    [Display(Name = "PostAuthor")]
    public string Author { get; set; }

    [Display(Name = "PostDescription")]
    public string? Description { get; set; }

    [Display(Name = "PostClassId")]
    public Guid ClassId { get; set; }

    [Display(Name = "PostContextValue")]
    public string ContextValue { get; set; }

    [Display(Name = "PostPicture")]
    public string? Picture { get; set; }

    [Display(Name = "PostSort")]
    public int Sort { get; set; }

    [Display(Name = "PostIsTop")]
    public bool IsTop { get; set; }


    [Display(Name = "PostTagNames")]
    public string[] PostTagNames { get; set; }

    [Display(Name = "PostPostsStatus")]
    public PostStatus PostsStatus { get; set; }
}
