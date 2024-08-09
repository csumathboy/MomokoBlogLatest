using MomokoBlog.Classifications;
using MomokoBlog.Classifications.Dtos;
using MomokoBlog.Comments;
using MomokoBlog.Comments.Dtos;
using MomokoBlog.Tags;
using MomokoBlog.Tags.Dtos;
using MomokoBlog.Posts;
using MomokoBlog.Posts.Dtos;
using AutoMapper;

namespace MomokoBlog;

public class MomokoBlogApplicationAutoMapperProfile : Profile
{
    public MomokoBlogApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Classification, ClassificationDto>();
        CreateMap<CreateUpdateClassificationDto, Classification>(MemberList.Source);
        CreateMap<Comment, CommentDto>();
        CreateMap<CreateCommentDto, Comment>(MemberList.Source);
        CreateMap<UpdateCommentDto, Comment>(MemberList.Source);
        CreateMap<Tag, TagDto>();
        CreateMap<CreateTagDto, Tag>(MemberList.Source);
        CreateMap<UpdateTagDto, Tag>(MemberList.Source);
        CreateMap<Post, PostDto>();
        CreateMap<PostWithDetails, PostDto>();
        CreateMap<CreatePostDto, Post>(MemberList.Source);
        CreateMap<UpdatePostDto, Post>(MemberList.Source);
    }
}
