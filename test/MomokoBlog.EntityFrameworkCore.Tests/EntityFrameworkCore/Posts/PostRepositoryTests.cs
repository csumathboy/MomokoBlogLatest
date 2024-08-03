using System;
using System.Threading.Tasks;
using MomokoBlog.Posts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace MomokoBlog.EntityFrameworkCore.Posts;

public class PostRepositoryTests : MomokoBlogEntityFrameworkCoreTestBase
{
    private readonly IRepository<Post, Guid> _postRepository;

    public PostRepositoryTests()
    {
        _postRepository = GetRequiredService<IRepository<Post, Guid>>();
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
