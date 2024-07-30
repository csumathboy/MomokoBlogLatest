using System;
using Volo.Abp.Domain.Repositories;

namespace MomokoBlog.Tags;

public interface ITagRepository : IRepository<Tag, Guid>
{
}
