using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MomokoBlog.Classifications;
using MomokoBlog.Classifications.Dtos;
using MomokoBlog.Web.Pages.Classifications.Classification.ViewModels;

namespace MomokoBlog.Web.Pages.Classifications.Classification;

public class CreateModalModel : MomokoBlogPageModel
{
    [BindProperty]
    public CreateEditClassificationViewModel ViewModel { get; set; }

    private readonly IClassificationAppService _service;

    public CreateModalModel(IClassificationAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditClassificationViewModel, CreateUpdateClassificationDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}