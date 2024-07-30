using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MomokoBlog.Comments;
using MomokoBlog.Comments.Dtos;
using MomokoBlog.Web.Pages.Comments.Comment.ViewModels;

namespace MomokoBlog.Web.Pages.Comments.Comment;

public class CreateModalModel : MomokoBlogPageModel
{
    [BindProperty]
    public CreateCommentViewModel ViewModel { get; set; }

    private readonly ICommentAppService _service;

    public CreateModalModel(ICommentAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateCommentViewModel, CreateCommentDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}