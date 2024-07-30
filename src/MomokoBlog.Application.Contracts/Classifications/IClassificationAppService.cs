using System;
using MomokoBlog.Classifications.Dtos;
using Volo.Abp.Application.Services;

namespace MomokoBlog.Classifications;


public interface IClassificationAppService :
    ICrudAppService< 
        ClassificationDto, 
        Guid, 
        ClassificationGetListInput,
        CreateUpdateClassificationDto,
        CreateUpdateClassificationDto>
{

}