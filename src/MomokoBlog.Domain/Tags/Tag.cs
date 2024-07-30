using MomokoBlog.Comments;
using System;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MomokoBlog.Tags;
public class Tag : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; } = default!;
    public string? NickName { get; set; }
    public int ArtCount { get; set; }

    /* This constructor is for deserialization / ORM purpose */
    public Tag()
    {
       
    }

    public Tag(string name, string? nickName)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), TagConsts.MaxNameLength);
        NickName = nickName;
        ArtCount = 0;
    }

    public void UpdateName(string newName)
    {
        Name = Check.NotNullOrWhiteSpace(newName, nameof(newName), TagConsts.MaxNameLength);    }

    public void UpdateNickName(string newNickName)
    {
        NickName = newNickName;
    }

    public void UpdateArtCount(int newArtCount)
    {
        ArtCount = newArtCount;
    }


    public Tag(
        Guid id,
        string name,
        string? nickName,
        int artCount
    ) : base(id)
    {
        Name = name;
        NickName = nickName;
        ArtCount = artCount;
    }
}
