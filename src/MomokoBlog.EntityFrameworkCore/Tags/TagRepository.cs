using System;
using System.Linq;
using System.Threading.Tasks;
using MomokoBlog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MomokoBlog.Tags;

public class TagRepository : EfCoreRepository<MomokoBlogDbContext, Tag, Guid>, ITagRepository
{
    public TagRepository(IDbContextProvider<MomokoBlogDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Tag>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}