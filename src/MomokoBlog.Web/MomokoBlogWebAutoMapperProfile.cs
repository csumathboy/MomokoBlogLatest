using MomokoBlog.Classifications.Dtos;
using MomokoBlog.Web.Pages.Classifications.Classification.ViewModels;
using MomokoBlog.Comments.Dtos;
using MomokoBlog.Web.Pages.Comments.Comment.ViewModels;
using MomokoBlog.Tags.Dtos;
using MomokoBlog.Web.Pages.Tags.Tag.ViewModels;
using MomokoBlog.Posts.Dtos;
using MomokoBlog.Web.Pages.Posts.Post.ViewModels;
using AutoMapper;
using MomokoBlog.Web.Models;

namespace MomokoBlog.Web;

public class MomokoBlogWebAutoMapperProfile : Profile
{
    public MomokoBlogWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<ClassificationDto, CreateEditClassificationViewModel>();
        CreateMap<CreateEditClassificationViewModel, CreateUpdateClassificationDto>();
        CreateMap<CommentDto, EditCommentViewModel>();
        CreateMap<CreateCommentViewModel, CreateCommentDto>();
        CreateMap<EditCommentViewModel, UpdateCommentDto>();
        CreateMap<TagDto, EditTagViewModel>();
        CreateMap<CreateTagViewModel, CreateTagDto>();
        CreateMap<EditTagViewModel, UpdateTagDto>();
        CreateMap<PostDto, UpdatePostDto>();
        CreateMap<PostDto, EditPostViewModel>();
        CreateMap<PostDetailsDto, EditPostViewModel>();
        CreateMap<CreatePostViewModel, CreatePostDto>();
        CreateMap<EditPostViewModel, UpdatePostDto>();
        CreateMap<TagDto, TagViewModel>();
    }
}
