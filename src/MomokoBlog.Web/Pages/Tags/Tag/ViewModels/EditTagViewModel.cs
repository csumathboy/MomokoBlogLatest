using System;
using System.ComponentModel.DataAnnotations;

namespace MomokoBlog.Web.Pages.Tags.Tag.ViewModels;

public class EditTagViewModel
{
    [Display(Name = "TagName")]
    public string Name { get; set; }

    [Display(Name = "TagNickName")]
    public string? NickName { get; set; }

    [Display(Name = "TagArtCount")]
    public int ArtCount { get; set; }
}
