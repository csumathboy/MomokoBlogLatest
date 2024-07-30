using MomokoBlog.Samples;
using Xunit;

namespace MomokoBlog.EntityFrameworkCore.Applications;

[Collection(MomokoBlogTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<MomokoBlogEntityFrameworkCoreTestModule>
{

}
