using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MomokoBlog.Tags;
using MomokoBlog.Tags.Dtos;
using MomokoBlog.Web.Pages.Tags.Tag.ViewModels;

namespace MomokoBlog.Web.Pages.Tags.Tag;

public class EditModalModel : MomokoBlogPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditTagViewModel ViewModel { get; set; }

    private readonly ITagAppService _service;

    public EditModalModel(ITagAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<TagDto, EditTagViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditTagViewModel, UpdateTagDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}