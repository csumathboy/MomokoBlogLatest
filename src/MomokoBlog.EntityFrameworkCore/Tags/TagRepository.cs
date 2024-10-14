using System;
using System.Linq;
using System.Threading;
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
    public async Task<Tag> GetByTagNameAsync(string tagName, CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();
        var query = dbset.AsQueryable();
        query = query.Where(x => x.Name.Equals(tagName));
        return query.First();
    }
    public override async Task<IQueryable<Tag>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}