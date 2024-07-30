using System;
using MomokoBlog.Tags.Dtos;
using Volo.Abp.Application.Services;

namespace MomokoBlog.Tags;


public interface ITagAppService :
    ICrudAppService< 
        TagDto, 
        Guid, 
        TagGetListInput,
        CreateTagDto,
        UpdateTagDto>
{

}