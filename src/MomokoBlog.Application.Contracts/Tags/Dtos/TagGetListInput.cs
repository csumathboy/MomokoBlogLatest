using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Tags.Dtos;

[Serializable]
public class TagGetListInput : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }

    public string? NickName { get; set; }

    public int? ArtCount { get; set; }
}