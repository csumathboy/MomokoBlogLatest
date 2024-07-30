using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MomokoBlog.Classifications;
using MomokoBlog.EntityFrameworkCore;
using MomokoBlog.Tags;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MomokoBlog.Posts;

public class PostRepository : EfCoreRepository<MomokoBlogDbContext, Post, Guid>, IPostRepository
{
    public PostRepository(IDbContextProvider<MomokoBlogDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override Task<IQueryable<Post>> WithDetailsAsync()
    {
        return base.WithDetailsAsync(x => x.PostTags);
    }

    public async Task<List<PostWithDetails>> GetListAsync(
          string sorting,
          int skipCount,
          int maxResultCount,
          CancellationToken cancellationToken = default
      )
    {
        var query = await ApplyFilterAsync();

        return await query
            .OrderBy(x => x.Sort)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }
    /// <summary>
    /// Query by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PostWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = await ApplyFilterAsync();
        if (query == null)
        {
            return new PostWithDetails();
        }
        return query.Where(x => x.Id == id).First();
    }

    /// <summary>
    /// Query by using Linq
    /// We can also use dbContext.Database.SqlQueryRaw<PostWithDetails>(sql,parms);
    /// </summary>
    /// <returns></returns>
    private async Task<IQueryable<PostWithDetails>> ApplyFilterAsync()
    {
        var dbContext = await GetDbContextAsync();

        return (await GetDbSetAsync())
            .Include(x => x.PostTags)
            .Join(dbContext.Set<Classification>(), post => post.ClassId, classification => classification.Id,
                (post, classification) => new { post, classification })
            .Select(x => new PostWithDetails
            {
                Id = x.post.Id,
                Title = x.post.Title,
                Author = x.post.Author,
                ContextValue = x.post.ContextValue,
                Description = x.post.Description,
                IsTop = x.post.IsTop,
                Picture = x.post.Picture,
                PostsStatus = x.post.PostsStatus,
                Sort = x.post.Sort,
                CreationTime = x.post.CreationTime,
                ClassName = x.classification.Name,
                PostTagNames = (from postTags in x.post.PostTags
                                join tag in dbContext.Set<Tag>() on postTags.TagId equals tag.Id
                                select tag.Name).ToArray()
            });
    }


}