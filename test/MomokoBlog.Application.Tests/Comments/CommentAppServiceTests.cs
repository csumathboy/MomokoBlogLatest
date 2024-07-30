using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MomokoBlog.Comments;

public class CommentAppServiceTests : MomokoBlogApplicationTestBase<MomokoBlogDomainTestModule>
{
    private readonly ICommentAppService _commentAppService;

    public CommentAppServiceTests()
    {
        _commentAppService = GetRequiredService<ICommentAppService>();
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

