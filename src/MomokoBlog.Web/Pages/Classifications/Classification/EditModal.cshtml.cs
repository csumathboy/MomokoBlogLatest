using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MomokoBlog.Classifications;
using MomokoBlog.Classifications.Dtos;
using MomokoBlog.Web.Pages.Classifications.Classification.ViewModels;

namespace MomokoBlog.Web.Pages.Classifications.Classification;

public class EditModalModel : MomokoBlogPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditClassificationViewModel ViewModel { get; set; }

    private readonly IClassificationAppService _service;

    public EditModalModel(IClassificationAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<ClassificationDto, CreateEditClassificationViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditClassificationViewModel, CreateUpdateClassificationDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}