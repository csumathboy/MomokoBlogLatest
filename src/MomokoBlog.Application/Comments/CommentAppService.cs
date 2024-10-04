using System;
using System.Linq;
using System.Threading.Tasks;
using MomokoBlog.Permissions;
using MomokoBlog.Comments.Dtos;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Comments;

[Authorize]
public class CommentAppService : CrudAppService<Comment, CommentDto, Guid, CommentGetListInput, CreateCommentDto, UpdateCommentDto>,
    ICommentAppService
{
    protected override string GetPolicyName { get; set; } = MomokoBlogPermissions.Comment.Default;
    protected override string GetListPolicyName { get; set; } = MomokoBlogPermissions.Comment.Default;
    protected override string CreatePolicyName { get; set; } = MomokoBlogPermissions.Comment.Create;
    protected override string UpdatePolicyName { get; set; } = MomokoBlogPermissions.Comment.Update;
    protected override string DeletePolicyName { get; set; } = MomokoBlogPermissions.Comment.Delete;

    private readonly ICommentRepository _repository;

    public CommentAppService(ICommentRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Comment>> CreateFilteredQueryAsync(CommentGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Title))
            .WhereIf(input.PostsId != null, x => x.PostsId == input.PostsId)
            .WhereIf(!input.Description.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Description))
            .WhereIf(!input.RealName.IsNullOrWhiteSpace(), x => x.RealName.Contains(input.RealName))
            .WhereIf(!input.Email.IsNullOrWhiteSpace(), x => x.Email.Contains(input.Email))
            .WhereIf(!input.PhoneNumber.IsNullOrWhiteSpace(), x => x.PhoneNumber.Contains(input.PhoneNumber))
            ;
    }
    [AllowAnonymous]
    public override async Task<PagedResultDto<CommentDto>> GetListAsync(CommentGetListInput input)
    {
        return await base.GetListAsync(input);
    }
    [AllowAnonymous]
    public override async Task<CommentDto> GetAsync(Guid id)
    {
        return await base.GetAsync(id);
    }
    
}
