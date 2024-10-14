using System;
using System.Threading.Tasks;
using MomokoBlog.Comments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MomokoBlog.Comments;


public interface ICommentAppService :
    ICrudAppService< 
        CommentDto, 
        Guid, 
        CommentGetListInput,
        CreateCommentDto,
        UpdateCommentDto>
{
}