using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace MomokoBlog.Posts;

public interface IPostRepository : IRepository<Post, Guid>
{
    Task<List<PostWithDetails>> GetListAsync(
      string sorting,
      int skipCount,
      int maxResultCount,
      CancellationToken cancellationToken = default
  );

    Task<PostWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
