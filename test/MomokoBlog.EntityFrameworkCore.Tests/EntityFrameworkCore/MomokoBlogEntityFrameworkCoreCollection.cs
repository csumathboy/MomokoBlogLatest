using Xunit;

namespace MomokoBlog.EntityFrameworkCore;

[CollectionDefinition(MomokoBlogTestConsts.CollectionDefinitionName)]
public class MomokoBlogEntityFrameworkCoreCollection : ICollectionFixture<MomokoBlogEntityFrameworkCoreFixture>
{

}
