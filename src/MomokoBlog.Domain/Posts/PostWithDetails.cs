using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Auditing;

namespace MomokoBlog.Posts
{
    public class PostWithDetails : IHasCreationTime
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = default!;

        public string Author { get; set; } = default!;

        public string? Description { get; set; }

        public string ClassName { get; set; } = default!;

        public string ContextValue { get; set; } = default!;

        public string? Picture { get; set; }

        public int Sort { get; set; } = 0;

        public bool IsTop { get; set; } = false;
 
        public PostStatus PostsStatus { get; set; }

        public string[] PostTagNames { get; set; } = default!;

        public DateTime CreationTime { get; set; }
    }
}