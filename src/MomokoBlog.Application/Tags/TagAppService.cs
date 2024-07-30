using System;
using System.Linq;
using System.Threading.Tasks;
using MomokoBlog.Permissions;
using MomokoBlog.Tags.Dtos;
using Volo.Abp.Application.Services;

namespace MomokoBlog.Tags;


public class TagAppService : CrudAppService<Tag, TagDto, Guid, TagGetListInput, CreateTagDto, UpdateTagDto>,
    ITagAppService
{
    protected override string GetPolicyName { get; set; } = MomokoBlogPermissions.Tag.Default;
    protected override string GetListPolicyName { get; set; } = MomokoBlogPermissions.Tag.Default;
    protected override string CreatePolicyName { get; set; } = MomokoBlogPermissions.Tag.Create;
    protected override string UpdatePolicyName { get; set; } = MomokoBlogPermissions.Tag.Update;
    protected override string DeletePolicyName { get; set; } = MomokoBlogPermissions.Tag.Delete;

    private readonly ITagRepository _repository;

    public TagAppService(ITagRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Tag>> CreateFilteredQueryAsync(TagGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(input.NickName != null, x => x.NickName == input.NickName)
            .WhereIf(input.ArtCount != null, x => x.ArtCount == input.ArtCount)
            ;
    }
}
