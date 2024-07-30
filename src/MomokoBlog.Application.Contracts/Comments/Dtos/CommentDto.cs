using System;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Comments.Dtos;

[Serializable]
public class CommentDto : FullAuditedEntityDto<Guid>
{
    public string Title { get; set; }

    public Guid PostsId { get; set; }

    public string Description { get; set; }

    public string RealName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}