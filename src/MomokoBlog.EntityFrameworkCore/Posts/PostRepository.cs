using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using MomokoBlog.Classifications;
using MomokoBlog.EntityFrameworkCore;
using MomokoBlog.Tags;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sorting"></param>
    /// <param name="skipCount"></param>
    /// <param name="maxResultCount"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="classId"></param>
    /// <param name="postStatus"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<PostWithDetails>> GetListAsync(
          string sorting,
          int skipCount,
          int maxResultCount,
          string title,
          string description,
          Guid classId,
          PostStatus? postStatus,
          CancellationToken cancellationToken = default
      )
    {
        var query = await ApplyFilterAsync(null, classId, postStatus, sorting, skipCount, maxResultCount, title, description);
        return query.ToList();

    }

    public async Task<List<PostWithDetails>> GetListByTagIdAsync(
         string sorting,
         int skipCount,
         int maxResultCount,
         Guid? tagId,
         PostStatus? postStatus,
         CancellationToken cancellationToken = default
     )
    {
        var dbContext = await GetDbContextAsync();
        var query = (await GetDbSetAsync())
            .Include(x => x.PostTags)
            .Join(dbContext.Set<PostTag>(), post => post.Id, tag => tag.PostId,
                (post, tag) => new { post, tag });
        if (tagId != null && !string.IsNullOrEmpty(tagId.ToString()))
        {
            query = query.Where(x => x.tag.TagId.Equals(tagId));
        }
        if (postStatus != null && postStatus > 0)
        {
            query = query.Where(x => x.post.PostsStatus.Equals(postStatus));
        }

        return query.Select(x => new PostWithDetails
        {
            Id = x.post.Id,
            Title = x.post.Title,
            Author = x.post.Author,
            Description = x.post.Description,
            IsTop = x.post.IsTop,
            Picture = x.post.Picture,
            ContextValue = x.post.ContextValue,
            PostsStatus = x.post.PostsStatus,
            Sort = x.post.Sort,
            CreationTime = x.post.CreationTime,
            //ClassName = ,
            PostTagNames = (from postTags in x.post.PostTags
                            join tag in dbContext.Set<Tag>() on postTags.TagId equals tag.Id
                            select tag.Name).ToArray()
        }).ToList();


    }
    /// <summary>
    /// Query by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PostWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = await ApplyFilterAsync(id, null);
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
    private async Task<IQueryable<PostWithDetails>> ApplyFilterAsync(
          Guid? id,
          Guid? classId,
          PostStatus? postStatus = null,
          string sorting = "",
          int skipCount = 0,
          int maxResultCount = 0,
          string title = "",
          string description = "")
    {
        var dbContext = await GetDbContextAsync();
        var query = (await GetDbSetAsync())
            .Include(x => x.PostTags)
            .Join(dbContext.Set<Classification>(), post => post.ClassId, classification => classification.Id,
                (post, classification) => new { post, classification });
        if (id != null && !string.IsNullOrEmpty(id.ToString()))
        {
            query = query.Where(x => x.post.Id.Equals(id));
        }
        if (classId != null && !string.IsNullOrEmpty(classId.ToString()))
        {
            query = query.Where(x => x.post.ClassId.Equals(classId));
        }
        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(x => x.post.Title.Contains(title));
        }
        if (!string.IsNullOrEmpty(description))
        {
            query = query.Where(x => x.post.Description.Contains(description));
        }
        if (postStatus != null && postStatus > 0)
        {
            query = query.Where(x => x.post.PostsStatus.Equals(postStatus));
        }
        query = query.OrderBy(x => x.post.Sort)
         .PageBy(skipCount, maxResultCount);
        return query.Select(x => new PostWithDetails
        {
            Id = x.post.Id,
            Title = x.post.Title,
            Author = x.post.Author,
            Description = x.post.Description,
            IsTop = x.post.IsTop,
            Picture = x.post.Picture,
            ContextValue = x.post.ContextValue,
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