using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MomokoBlog.Tags;

public class TagAppServiceTests : MomokoBlogApplicationTestBase<MomokoBlogDomainTestModule>
{
    private readonly ITagAppService _tagAppService;

    public TagAppServiceTests()
    {
        _tagAppService = GetRequiredService<ITagAppService>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Act

        // Assert
    }
    */
}

