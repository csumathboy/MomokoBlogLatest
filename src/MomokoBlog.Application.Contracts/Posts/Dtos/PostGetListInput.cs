using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Posts.Dtos;

[Serializable]
public class PostGetListInput : PagedAndSortedResultRequestDto
{ 
    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Description { get; set; }

    public Guid? ClassId { get; set; }

    public string? ContextValue { get; set; }

    public string? Picture { get; set; }

    public int? Sort { get; set; }

    public bool? IsTop { get; set; }

    public PostStatus? PostsStatus { get; set; }
}