using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MomokoBlog.Posts;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace MomokoBlog.Web.Pages.Posts.Post.ViewModels;

public class CreatePostViewModel
{
    [Display(Name = "PostTitle")]
    public string Title { get; set; }

    [Display(Name = "PostAuthor")]
    public string Author { get; set; }

    [Display(Name = "PostDescription")]
    [TextArea(Rows = 4)]
    public string? Description { get; set; }

    [Display(Name = "PostClassId")]
    public Guid ClassId { get; set; }

    [Display(Name = "PostContextValue")]
    [TextArea(Rows = 10)]
    public string ContextValue { get; set; }

    [Display(Name = "PostPicture")]
    public string? Picture { get; set; }

    [Display(Name = "PostSort")]
    public int Sort { get; set; }

    [Display(Name = "PostIsTop")]

    public bool IsTop { get; set; }

    [Display(Name = "PostTagNames")]
    public string[]? PostTagNames { get; set; }

    [Display(Name = "PostPostsStatus")]
    public PostStatus PostsStatus { get; set; }

    [Required]
    [Display(Name = "File")]
    public IFormFile File { get; set; }

    [Required]
    [Display(Name = "Filename")]
    public string Name { get; set; }
}
