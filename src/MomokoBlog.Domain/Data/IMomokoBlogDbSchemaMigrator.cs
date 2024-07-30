using System.Threading.Tasks;

namespace MomokoBlog.Data;

public interface IMomokoBlogDbSchemaMigrator
{
    Task MigrateAsync();
}
