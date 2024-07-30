using System;
using Volo.Abp.Domain.Entities;

namespace MomokoBlog.Posts;

public class PostTag : Entity
{
    public Guid PostId { get; set; }

    public Guid TagId { get; set; }


    /* This constructor is for deserialization / ORM purpose */
    private PostTag()
    {
    }

    public PostTag(Guid postId, Guid tagId)
    {
        PostId = postId;
        TagId = tagId;
    }

    public override object[] GetKeys()
    {
        return new object[] { PostId, TagId };
    }

}
