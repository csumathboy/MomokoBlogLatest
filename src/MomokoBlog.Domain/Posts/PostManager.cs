using System;
using System.Linq;
using System.Threading.Tasks;
using MomokoBlog.Tags;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace MomokoBlog.Posts
{
    public class PostManager : DomainService
    {
        private readonly IPostRepository _postRepository;
        private readonly IRepository<Tag, Guid> _tagRepository;

        public PostManager(IPostRepository postRepository, IRepository<Tag, Guid> tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }
        /// <summary>
        /// Create Post
        /// </summary>
        /// <param name="title"></param>
        /// <param name="classId"></param>
        /// <param name="author"></param>
        /// <param name="description"></param>
        /// <param name="contextValue"></param>
        /// <param name="picture"></param>
        /// <param name="sort"></param>
        /// <param name="isTop"></param>
        /// <param name="postsStatus"></param>
        /// <param name="tagNames"></param>
        /// <returns></returns>
        public async Task<Post> CreateAsync(string title, Guid classId, string author, string description, string contextValue, string picture, int sort, bool isTop, PostStatus postsStatus, [CanBeNull] string[] tagNames)
        {
            var post = new Post(GuidGenerator.Create(), title, classId, author, description, contextValue, picture, sort, isTop, postsStatus);

            await SetPostTagsAsync(post, tagNames);

            return await _postRepository.InsertAsync(post);
        }
        /// <summary>
        /// Update Post
        /// </summary>
        /// <param name="post"></param>
        /// <param name="title"></param>
        /// <param name="classId"></param>
        /// <param name="author"></param>
        /// <param name="description"></param>
        /// <param name="contextValue"></param>
        /// <param name="picture"></param>
        /// <param name="sort"></param>
        /// <param name="isTop"></param>
        /// <param name="postsStatus"></param>
        /// <param name="tagNames"></param>
        /// <returns></returns>
        public async Task<Post> UpdateAsync(
            Post post,
            string title, Guid classId, string author, string description, string contextValue, string picture, int sort, bool isTop, PostStatus postsStatus,
            [CanBeNull] string[] tagNames
        )
        {
            post.SetTitle(title);
            post.ClassId = classId;
            post.SetAuthor(author);
            post.SetDescription(description);
            post.SetPicture(picture);
            post.Sort=sort;
            post.IsTop=isTop;
            post.PostsStatus=postsStatus;

            await SetPostTagsAsync(post, tagNames);

            return await _postRepository.UpdateAsync(post);
        }
        /// <summary>
        /// Set PostTags
        /// </summary>
        /// <param name="post"></param>
        /// <param name="tagNames"></param>
        /// <returns></returns>
        private async Task SetPostTagsAsync(Post post, [CanBeNull] string[] tagNames)
        {
            if (tagNames == null || !tagNames.Any())
            {
                post.RemoveAllPostTags();
                return;
            }

            var query = (await _tagRepository.GetQueryableAsync())
                .Where(x => tagNames.Contains(x.Name))
                .Select(x => x.Id)
                .Distinct();

            var tagIds = await AsyncExecuter.ToListAsync(query);
            if (!tagIds.Any())
            {
                return;
            }

            post.RemoveAllPostTagsExceptGivenIds(tagIds);

            foreach (var tagId in tagIds)
            {
                post.AddPostTag(tagId);
            }
        }
    }
}