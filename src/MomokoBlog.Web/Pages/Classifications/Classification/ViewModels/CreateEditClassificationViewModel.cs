using System;
using System.ComponentModel.DataAnnotations;

namespace MomokoBlog.Web.Pages.Classifications.Classification.ViewModels;

public class CreateEditClassificationViewModel
{
    [Display(Name = "ClassificationName")]
    public string Name { get; set; }

    [Display(Name = "ClassificationDescription")]
    public string? Description { get; set; }

    [Display(Name = "ClassificationNickName")]
    public string? NickName { get; set; }

    [Display(Name = "ClassificationArtCount")]
    public int ArtCount { get; set; }
}
