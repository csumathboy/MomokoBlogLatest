using System;
using MomokoBlog.Posts.Dtos;
using Volo.Abp.Application.Services;
using MomokoBlog.Classifications;
using MomokoBlog.Tags;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Posts;


public interface IPostAppService :
    ICrudAppService< 
        PostDto, 
        Guid, 
        PostGetListInput,
        CreatePostDto,
        UpdatePostDto>
{
    Task<PagedResultDto<PostDto>> GetListByConditionAsync(GetPostListDto input);

    
}