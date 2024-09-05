using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MomokoBlog.BlobFile;
using MomokoBlog.Posts;
using MomokoBlog.Posts.Dtos;
using MomokoBlog.Tags.Dtos;
using MomokoBlog.Web.Models;
using MomokoBlog.Web.Pages.Posts.Post.ViewModels;

namespace MomokoBlog.Web.Pages.Posts.Post;

public class EditModalModel : MomokoBlogPageModel
{
    [BindProperty]
    public EditPostViewModel EditModel { get; set; }

    [BindProperty]
    public List<TagViewModel> Tags { get; set; }

    public List<SelectListItem> ClassificationList { get; set; }

    private readonly IFileAppService _fileAppService;

    public bool Uploaded { get; set; } = false;

    private readonly IPostAppService _service;

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

 

    public EditModalModel(IPostAppService service, IFileAppService fileAppService)
    {
        _service = service;
        _fileAppService = fileAppService;
    }

    public List<SelectListItem> YesNoList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "Yes"},
            new SelectListItem { Value = "1", Text = "No"},
        };
    public async Task OnGetAsync()
    {
        var dto = await _service.GetPostWithDetails(Id);
        EditModel = ObjectMapper.Map<PostDetailsDto, EditPostViewModel>(dto);
        EditModel.TempContextValue = EditModel.ContextValue;
        //Get all classification and fill the select list
        var classLookup = await _service.GetClassificationAsync();
        ClassificationList = classLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        //Get all categories
        var tagLookupDto = await _service.GetTagAsync();
        Tags = ObjectMapper.Map<List<TagDto>, List<TagViewModel>>(tagLookupDto.Items.ToList());
    }


    public virtual async Task<IActionResult> OnPostAsync()
    {

        var dto = ObjectMapper.Map<EditPostViewModel, UpdatePostDto>(EditModel);
        var fileName = GuidGenerator.Create().ToString() + "_" + EditModel.File.FileName;
        dto.Picture = "/uploadfiles/host/blob-file-container/" + fileName;

        using (var memoryStream = new MemoryStream())
        {
            await EditModel.File.CopyToAsync(memoryStream);

            await _fileAppService.SaveBlobAsync(
                new SaveBlobInputDto
                {
                    Name = fileName,
                    Content = memoryStream.ToArray()
                }
            );
        }

        var selectedTags = Tags.Where(x => x.IsSelected).ToList();
        if (selectedTags.Any())
        {
            var postTagNames = selectedTags.Select(x => x.Name).ToArray();
            dto.PostTagNames = postTagNames;
        }

        await _service.UpdateAsync(Id, dto);
   
        return NoContent();
    }

}