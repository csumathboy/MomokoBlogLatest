using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MomokoBlog.Posts;
using MomokoBlog.Posts.Dtos;
 
namespace MomokoBlog.Web.Pages.Posts.Post;

public class CreateModalModel : MomokoBlogPageModel
{
    [BindProperty]
    public CreatePostDto ViewModel { get; set; }

    private readonly IPostAppService _service;

    public CreateModalModel(IPostAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        await _service.CreateAsync(ViewModel);
        return NoContent();
    }
}