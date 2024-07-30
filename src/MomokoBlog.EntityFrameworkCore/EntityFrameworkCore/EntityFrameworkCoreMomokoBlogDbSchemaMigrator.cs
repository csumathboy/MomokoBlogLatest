using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MomokoBlog.Data;
using Volo.Abp.DependencyInjection;

namespace MomokoBlog.EntityFrameworkCore;

public class EntityFrameworkCoreMomokoBlogDbSchemaMigrator
    : IMomokoBlogDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMomokoBlogDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the MomokoBlogDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MomokoBlogDbContext>()
            .Database
            .MigrateAsync();
    }
}
