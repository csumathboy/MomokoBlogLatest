using MomokoBlog.Classifications;
using System;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MomokoBlog.Comments;
public class Comment : FullAuditedAggregateRoot<Guid>
{
    public string Title { get; set; } = default!;
    public Guid PostsId { get; set; }
    public string Description { get; set; } = default!;
    public string RealName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    /* This constructor is for deserialization / ORM purpose */
    public Comment()
    { 
    
    }

    public Comment(string title, Guid postsId, string description, string realName, string email, string phoneNumber)
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title), CommentConsts.MaxNameLength);
        PostsId = postsId;
        Description = description;
        RealName = realName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public void UpdateTitle(string newTitle)
    {
        Title = Check.NotNullOrWhiteSpace(newTitle, nameof(newTitle), CommentConsts.MaxNameLength);
    }

    public void UpdateRealName(string newRealName)
    {
        RealName = newRealName;
    }
 
    public void UpdateDescription(string newDescription)
    {
        Description = newDescription;
    }

    public void UpdateEmail(string newEmail)
    {
        Email = newEmail;
    }

    public void UpdatePhoneNumber(string newPhoneNumber)
    {
        PhoneNumber = newPhoneNumber;
    }



    public Comment(
        Guid id,
        string title,
        Guid postsId,
        string description,
        string realName,
        string email,
        string phoneNumber
    ) : base(id)
    {
        Title = title;
        PostsId = postsId;
        Description = description;
        RealName = realName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
