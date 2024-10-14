using MomokoBlog.Posts;
using System;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace MomokoBlog.Tags;

public interface ITagRepository : IRepository<Tag, Guid>
{
    Task<Tag> GetByTagNameAsync(string tagName, CancellationToken cancellationToken = default);
}
