using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Classifications.Dtos;

[Serializable]
public class ClassificationGetListInput : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? NickName { get; set; }

    public int? ArtCount { get; set; }
}