using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MomokoBlog.Classifications;

public class ClassificationAppServiceTests : MomokoBlogApplicationTestBase<MomokoBlogDomainTestModule>
{
    private readonly IClassificationAppService _classificationAppService;

    public ClassificationAppServiceTests()
    {
        _classificationAppService = GetRequiredService<IClassificationAppService>();
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

