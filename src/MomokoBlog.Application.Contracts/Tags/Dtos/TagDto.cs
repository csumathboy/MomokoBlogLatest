using System;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Tags.Dtos;

[Serializable]
public class TagDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string? NickName { get; set; }

    public int ArtCount { get; set; }
}