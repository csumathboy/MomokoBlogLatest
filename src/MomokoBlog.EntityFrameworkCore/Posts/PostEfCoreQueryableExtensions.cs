using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MomokoBlog.Posts;

public static class PostEfCoreQueryableExtensions
{
    public static IQueryable<Post> IncludeDetails(this IQueryable<Post> queryable, bool include = true)
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
