using System;
using System.Linq;
using System.Threading.Tasks;
using MomokoBlog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MomokoBlog.Classifications;

public class ClassificationRepository : EfCoreRepository<MomokoBlogDbContext, Classification, Guid>, IClassificationRepository
{
    public ClassificationRepository(IDbContextProvider<MomokoBlogDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Classification>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}