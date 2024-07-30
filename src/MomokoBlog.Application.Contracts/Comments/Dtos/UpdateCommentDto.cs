using System;

namespace MomokoBlog.Comments.Dtos;

[Serializable]
public class UpdateCommentDto
{
    public string Title { get; set; }

    public Guid PostsId { get; set; }

    public string Description { get; set; }

    public string RealName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}