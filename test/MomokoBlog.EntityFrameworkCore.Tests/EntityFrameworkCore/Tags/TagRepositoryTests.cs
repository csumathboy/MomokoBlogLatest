using System;
using System.Threading.Tasks;
using MomokoBlog.Tags;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace MomokoBlog.EntityFrameworkCore.Tags;

public class TagRepositoryTests : MomokoBlogEntityFrameworkCoreTestBase
{
    private readonly ITagRepository _tagRepository;

    public TagRepositoryTests()
    {
        _tagRepository = GetRequiredService<ITagRepository>();
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
