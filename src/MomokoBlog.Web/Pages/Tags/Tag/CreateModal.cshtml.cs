using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MomokoBlog.Tags;
using MomokoBlog.Tags.Dtos;
using MomokoBlog.Web.Pages.Tags.Tag.ViewModels;

namespace MomokoBlog.Web.Pages.Tags.Tag;

public class CreateModalModel : MomokoBlogPageModel
{
    [BindProperty]
    public CreateTagViewModel ViewModel { get; set; }

    private readonly ITagAppService _service;

    public CreateModalModel(ITagAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateTagViewModel, CreateTagDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}