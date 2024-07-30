using Volo.Abp.Modularity;

namespace MomokoBlog;

[DependsOn(
    typeof(MomokoBlogApplicationModule),
    typeof(MomokoBlogDomainTestModule)
)]
public class MomokoBlogApplicationTestModule : AbpModule
{

}
