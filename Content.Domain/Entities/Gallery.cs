namespace Content.Domain.Entities
{
    using Enums;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using global::Content.Domain.ValueObjects;

    public class Gallery : Content
    {
        private readonly ICollection<ImageUrl> _imageUrls = new HashSet<ImageUrl>();

        [Obsolete("Only for reflection", true)]
        public Gallery() { }

        protected internal Gallery(string name, User creator, string coverUrl, List<string> imagesUrls)
            : base(ContentCategory.Gallery, name, creator)
        {
            SetCoverUrl(coverUrl);
        }

        public virtual string CoverUrl { get; protected set; }
        public virtual IEnumerable<ImageUrl> ImageUrls => _imageUrls;

        public virtual List<string> ImagesUrls =>
            _imageUrls?.Any() == true ?
            _imageUrls.AsQueryable().Select(x => x.Url).ToList():
            new List<string>();


        public virtual void SetCoverUrl(string coverUrl)
        {
            CoverUrl = coverUrl ?? throw new ArgumentNullException(nameof(coverUrl));
        }

        public virtual void SetImagesUrls(List<string> imagesUrls)
        {
            _imageUrls.Clear();
            if (imagesUrls != null)
            {
                foreach (var url in imagesUrls)
                {
                    var imageUrl = new ImageUrl(url);
                    _imageUrls.Add(imageUrl);
                }
            }
        }
    }
}
