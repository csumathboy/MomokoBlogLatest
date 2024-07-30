using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MomokoBlog.Comments;
using MomokoBlog.Comments.Dtos;
using MomokoBlog.Web.Pages.Comments.Comment.ViewModels;

namespace MomokoBlog.Web.Pages.Comments.Comment;

public class EditModalModel : MomokoBlogPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditCommentViewModel ViewModel { get; set; }

    private readonly ICommentAppService _service;

    public EditModalModel(ICommentAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<CommentDto, EditCommentViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditCommentViewModel, UpdateCommentDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}