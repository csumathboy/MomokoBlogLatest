using MomokoBlog.Samples;
using Xunit;

namespace MomokoBlog.EntityFrameworkCore.Domains;

[Collection(MomokoBlogTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<MomokoBlogEntityFrameworkCoreTestModule>
{

}
