using System;
using System.Linq;
using System.Threading.Tasks;
using MomokoBlog.Permissions;
using MomokoBlog.Classifications.Dtos;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;

namespace MomokoBlog.Classifications;

[Authorize]
public class ClassificationAppService : CrudAppService<Classification, ClassificationDto, Guid, ClassificationGetListInput, CreateUpdateClassificationDto, CreateUpdateClassificationDto>,
    IClassificationAppService
{
    protected override string GetPolicyName { get; set; } = MomokoBlogPermissions.Classification.Default;
    protected override string GetListPolicyName { get; set; } = MomokoBlogPermissions.Classification.Default;
    protected override string CreatePolicyName { get; set; } = MomokoBlogPermissions.Classification.Create;
    protected override string UpdatePolicyName { get; set; } = MomokoBlogPermissions.Classification.Update;
    protected override string DeletePolicyName { get; set; } = MomokoBlogPermissions.Classification.Delete;

    private readonly IClassificationRepository _repository;

    public ClassificationAppService(IClassificationRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Classification>> CreateFilteredQueryAsync(ClassificationGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(input.Description != null, x => x.Description.Contains(input.Description))
            .WhereIf(input.NickName != null, x => x.NickName == input.NickName)
            .WhereIf(input.ArtCount != null, x => x.ArtCount == input.ArtCount)
            ;
    }
    [AllowAnonymous]
    public override async Task<PagedResultDto<ClassificationDto>> GetListAsync(ClassificationGetListInput input)
    {
        return await base.GetListAsync(input);
    }
    [AllowAnonymous]
    public override async Task<ClassificationDto> GetAsync(Guid id)
    {
        return await base.GetAsync(id);
    }
}
