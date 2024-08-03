using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MomokoBlog.BlobFile
{
    public interface IFileAppService : IApplicationService
    {
        Task SaveBlobAsync(SaveBlobInputDto input);

        Task<BlobDto> GetBlobAsync(GetBlobRequestDto input);
    }
}
