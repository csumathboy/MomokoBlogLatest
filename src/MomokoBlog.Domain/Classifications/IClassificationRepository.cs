using System;
using Volo.Abp.Domain.Repositories;

namespace MomokoBlog.Classifications;

public interface IClassificationRepository : IRepository<Classification, Guid>
{
}
