using Volo.Abp.Modularity;

namespace MomokoBlog;

[DependsOn(
    typeof(MomokoBlogDomainModule),
    typeof(MomokoBlogTestBaseModule)
)]
public class MomokoBlogDomainTestModule : AbpModule
{

}
