using System;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Classifications.Dtos;

[Serializable]
public class ClassificationDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? NickName { get; set; }

    public int ArtCount { get; set; }
}