namespace Content.Domain.Entities
{
    using Enums;
    using System;
    using System.Collections.Generic;
    public class Gallery : Content
    {
        private readonly ICollection<ImageUrl> _imagesUrls = new HashSet<ImageUrl>();

        [Obsolete("Only for reflection", true)]
        public Gallery() { }

        protected internal Gallery(string name, User creator, string coverUrl, List<string> imagesUrls)
            : base(ContentCategory.Gallery, name, creator)
        {
            SetCoverUrl(coverUrl);
        }

        public virtual string CoverUrl { get; protected set; }
        public virtual IEnumerable<ImageUrl> ImagesUrls => _imagesUrls;


        public virtual void SetCoverUrl(string coverUrl)
        {
            CoverUrl = coverUrl ?? throw new ArgumentNullException(nameof(coverUrl));
        }
    }
}
