using System;
using Volo.Abp.Domain.Repositories;

namespace MomokoBlog.Comments;

public interface ICommentRepository : IRepository<Comment, Guid>
{
}
