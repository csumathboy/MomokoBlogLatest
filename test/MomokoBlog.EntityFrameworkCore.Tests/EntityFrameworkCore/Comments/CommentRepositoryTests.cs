using System;
using System.Threading.Tasks;
using MomokoBlog.Comments;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace MomokoBlog.EntityFrameworkCore.Comments;

public class CommentRepositoryTests : MomokoBlogEntityFrameworkCoreTestBase
{
    private readonly ICommentRepository _commentRepository;

    public CommentRepositoryTests()
    {
        _commentRepository = GetRequiredService<ICommentRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}
