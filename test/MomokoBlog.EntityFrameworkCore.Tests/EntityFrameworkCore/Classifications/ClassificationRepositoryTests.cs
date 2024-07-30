using System;
using System.Threading.Tasks;
using MomokoBlog.Classifications;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace MomokoBlog.EntityFrameworkCore.Classifications;

public class ClassificationRepositoryTests : MomokoBlogEntityFrameworkCoreTestBase
{
    private readonly IClassificationRepository _classificationRepository;

    public ClassificationRepositoryTests()
    {
        _classificationRepository = GetRequiredService<IClassificationRepository>();
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
