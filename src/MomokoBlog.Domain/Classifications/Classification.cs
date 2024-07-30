using System;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MomokoBlog.Classifications;
public class Classification : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? NickName { get; set; }
    public int ArtCount { get; set; }

    /* This constructor is for deserialization / ORM purpose */
    public Classification()
    {

    }

    public Classification(string name, string? nickName, string? description)
    {
        Name = name;
        NickName = nickName;
        Description = description;
        ArtCount = 0;
    }

    public void UpdateName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), ClassificationConsts.MaxNameLength);
    }

    public void UpdateNickName(string nickName)
    {
        NickName = Check.NotNullOrWhiteSpace(nickName, nameof(nickName), ClassificationConsts.MaxNameLength);
    }

    public void UpdateDescription(string description)
    {
        Description = Check.NotNullOrWhiteSpace(description, nameof(description), ClassificationConsts.MaxDescriptionLength);
    }

    public void UpdateArtCount(int artCount)
    {
        ArtCount = Check.Positive(artCount, nameof(artCount));
    }

 
    public Classification(
        Guid id,
        string name,
        string? description,
        string? nickName,
        int artCount
    ) : base(id)
    {
        Name = name;
        Description = description;
        NickName = nickName;
        ArtCount = artCount;
    }
}
