using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MomokoBlog.Classifications;

public static class ClassificationEfCoreQueryableExtensions
{
    public static IQueryable<Classification> IncludeDetails(this IQueryable<Classification> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
