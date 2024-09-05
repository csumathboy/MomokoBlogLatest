using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MomokoBlog.Classifications;
using MomokoBlog.Classifications.Dtos;
using MomokoBlog.Permissions;
using MomokoBlog.Posts.Dtos;
using MomokoBlog.Tags;
using MomokoBlog.Tags.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using static MomokoBlog.Permissions.MomokoBlogPermissions;

namespace MomokoBlog.Posts;


public class PostAppService : CrudAppService<Post, PostDto, Guid, PostGetListInput, CreatePostDto, UpdatePostDto>,
    IPostAppService
{
    protected override string GetPolicyName { get; set; } = MomokoBlogPermissions.Post.Default;
    protected override string GetListPolicyName { get; set; } = MomokoBlogPermissions.Post.Default;
    protected override string CreatePolicyName { get; set; } = MomokoBlogPermissions.Post.Create;
    protected override string UpdatePolicyName { get; set; } = MomokoBlogPermissions.Post.Update;
    protected override string DeletePolicyName { get; set; } = MomokoBlogPermissions.Post.Delete;

    private readonly IPostRepository _postRepository;
    private readonly PostManager _postManager;
    private readonly IClassificationRepository _classificationRepository;
    private readonly ITagRepository _categoryRepository;

    public PostAppService(IPostRepository repository,
        PostManager postManager,
        IClassificationRepository classificationRepository,
        ITagRepository categoryRepository) : base(repository)
    {
        _postRepository = repository;
        _postManager = postManager;
        _classificationRepository = classificationRepository;
        _categoryRepository = categoryRepository;
    }

    protected override async Task<IQueryable<Post>> CreateFilteredQueryAsync(PostGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Title))
            .WhereIf(!input.Author.IsNullOrWhiteSpace(), x => x.Author.Contains(input.Author))
            .WhereIf(input.Description != null, x => x.Description == input.Description)
            .WhereIf(input.ClassId != null, x => x.ClassId == input.ClassId)
            .WhereIf(!input.ContextValue.IsNullOrWhiteSpace(), x => x.ContextValue.Contains(input.ContextValue))
            .WhereIf(input.Picture != null, x => x.Picture == input.Picture)
            .WhereIf(input.Sort != null, x => x.Sort == input.Sort)
            .WhereIf(input.IsTop != null, x => x.IsTop == input.IsTop)
            .WhereIf(input.PostsStatus != null, x => x.PostsStatus == input.PostsStatus);
    }

    public async Task<PagedResultDto<PostDto>> GetListByConditionAsync(GetPostListDto input)
    {
        var posts = await _postRepository.GetListAsync(input.Sorting ?? nameof(Post.Sort), input.SkipCount, input.MaxResultCount);
        var totalCount = await _postRepository.CountAsync();

        return new PagedResultDto<PostDto>(totalCount, ObjectMapper.Map<List<PostWithDetails>, List<PostDto>>(posts));
    }

    public override async Task<PostDto> GetAsync(Guid id)
    {
        var post = await _postRepository.GetAsync(id);

        return ObjectMapper.Map<PostWithDetails, PostDto>(post);
    }
    public  async Task<PostDetailsDto> GetPostWithDetails(Guid id)
    {
        var post = await _postRepository.GetAsync(id);

        return ObjectMapper.Map<PostWithDetails, PostDetailsDto>(post);
    }
    public override async Task<PostDto> CreateAsync(CreatePostDto input)
    {
        var result= await _postManager.CreateAsync(
             input.Title,
             input.ClassId,
             input.Author,
             input.Description ?? string.Empty,
             input.ContextValue,
             input.Picture ?? string.Empty,
             input.Sort,
             input.IsTop,
             input.PostsStatus,
             input.PostTagNames
        );
        return ObjectMapper.Map<Post, PostDto>(result);
    }

    public override async Task<PostDto> UpdateAsync(Guid id, UpdatePostDto input)
    {
        var post = await _postRepository.GetAsync(id, includeDetails: true);

        var result = await _postManager.UpdateAsync(
            post,
             input.Title,
             input.ClassId,
             input.Author,
             input.Description ?? string.Empty,
             input.ContextValue,
             input.Picture ?? string.Empty,
             input.Sort,
             input.IsTop,
             input.PostsStatus,
             input.PostTagNames
        );
        return ObjectMapper.Map<Post, PostDto>(result);
    }

    public override async Task DeleteAsync(Guid id)
    {
        await _postRepository.DeleteAsync(id);
    }

    public async Task<ListResultDto<ClassificationDto>> GetClassificationAsync()
    {
        var classifications = await _classificationRepository.GetListAsync();

        return new ListResultDto<ClassificationDto>(
            ObjectMapper.Map<List<Classifications.Classification>, List<ClassificationDto>>(classifications)
        );
    }

    public async Task<ListResultDto<TagDto>> GetTagAsync()
    {
        var categories = await _categoryRepository.GetListAsync();

        return new ListResultDto<TagDto>(
            ObjectMapper.Map<List<Tags.Tag>, List<TagDto>>(categories)
        );
    }
}
