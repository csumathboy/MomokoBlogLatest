using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MomokoBlog.Posts;

public class PostAppServiceTests : MomokoBlogApplicationTestBase
{
    private readonly IPostAppService _postAppService;

    public PostAppServiceTests()
    {
        _postAppService = GetRequiredService<IPostAppService>();
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

