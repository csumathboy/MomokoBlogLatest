using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MomokoBlog.BlobFile;
using MomokoBlog.Posts;
using MomokoBlog.Posts.Dtos;
using MomokoBlog.Tags.Dtos;
using MomokoBlog.Web.Models;
using MomokoBlog.Web.Pages.Posts.Post.ViewModels;

namespace MomokoBlog.Web.Pages.Posts.Post;


[IgnoreAntiforgeryToken(Order = 1001)]
public class CreateModalModel : MomokoBlogPageModel
{
    [BindProperty]
    public CreatePostViewModel ViewModel { get; set; }

    [BindProperty]
    public List<TagViewModel> Tags { get; set; }

    public List<SelectListItem> ClassificationList { get; set; }

    private readonly IFileAppService _fileAppService;

    public bool Uploaded { get; set; } = false;

    private readonly IPostAppService _service;




    public CreateModalModel(IPostAppService service, IFileAppService fileAppService)
    {
        _service = service;
        _fileAppService = fileAppService;
    }

    public List<SelectListItem> YesNoList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "是"},
            new SelectListItem { Value = "0", Text = "否"},
        };
    public List<SelectListItem> PostStatusList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "未决定"},
            new SelectListItem { Value = "1", Text = "已发布"},
            new SelectListItem { Value = "2", Text = "待发布"},
            new SelectListItem { Value = "3", Text = "已删除"}
        };



    public async Task OnGetAsync()
    {

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

        var dto = ObjectMapper.Map<CreatePostViewModel, CreatePostDto>(ViewModel);

        if (ViewModel.File != null)
        {
            var fileName = GuidGenerator.Create().ToString() + "_" + ViewModel.File.FileName;
            dto.Picture = "/uploadfiles/host/blob-file-container/" + fileName;

            using (var memoryStream = new MemoryStream())
            {
                await ViewModel.File.CopyToAsync(memoryStream);

                await _fileAppService.SaveBlobAsync(
                    new SaveBlobInputDto
                    {
                        Name = fileName,
                        Content = memoryStream.ToArray()
                    }
                );
            }
        }


        var selectedTags = Tags.Where(x => x.IsSelected).ToList();
        if (selectedTags.Any())
        {
            var postTagNames = selectedTags.Select(x => x.Name).ToArray();
            dto.PostTagNames = postTagNames;
        }

        await _service.CreateAsync(dto);

        return Redirect("/Posts/Post");
    }



}




