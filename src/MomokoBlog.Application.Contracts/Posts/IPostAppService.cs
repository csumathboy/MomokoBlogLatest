using System;
using MomokoBlog.Posts.Dtos;
using Volo.Abp.Application.Services;
using MomokoBlog.Classifications;
using MomokoBlog.Tags;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using MomokoBlog.Classifications.Dtos;
using MomokoBlog.Tags.Dtos;

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
    Task<ListResultDto<ClassificationDto>> GetClassificationAsync();
    Task<ListResultDto<TagDto>> GetTagAsync();
    Task<PostDetailsDto> GetPostWithDetails(Guid id);
}