using System;
using System.Linq;
using System.Threading.Tasks;
using MomokoBlog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MomokoBlog.Comments;

public class CommentRepository : EfCoreRepository<MomokoBlogDbContext, Comment, Guid>, ICommentRepository
{
    public CommentRepository(IDbContextProvider<MomokoBlogDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Comment>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}