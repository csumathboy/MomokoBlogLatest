using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MomokoBlog.Posts;
using MomokoBlog.Posts.Dtos;
 
namespace MomokoBlog.Web.Pages.Posts.Post;

public class EditModalModel : MomokoBlogPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public UpdatePostDto ViewModel { get; set; }

    private readonly IPostAppService _service;

    public EditModalModel(IPostAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<PostDto, UpdatePostDto>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        await _service.UpdateAsync(Id, ViewModel);
        return NoContent();
    }
}