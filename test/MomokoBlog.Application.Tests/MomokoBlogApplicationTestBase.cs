using Volo.Abp.Modularity;

namespace MomokoBlog;

public abstract class MomokoBlogApplicationTestBase<TStartupModule> : MomokoBlogTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
