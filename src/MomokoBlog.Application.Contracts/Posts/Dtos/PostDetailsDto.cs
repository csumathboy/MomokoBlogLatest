using System;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Posts.Dtos;

[Serializable]
public class PostDetailsDto : FullAuditedEntityDto<Guid>
{
    public string Title { get; set; }

    public string Author { get; set; }
     
    public string? Description { get; set; }

    public string ContextValue { get; set; } = default!;

    public string? ClassName { get; set; }

    public string? Picture { get; set; }

    public int Sort { get; set; }

    public bool IsTop { get; set; }

    public string[] PostTagNames { get; set; } = default!;

    public PostStatus PostsStatus { get; set; }
}