namespace Content.Domain.Entities
{
    using Enums;
    using System;
    using System.Collections.Generic;
    public class Gallery : Content
    {
        [Obsolete("Only for reflection", true)]
        public Gallery() { }

        protected internal Gallery(string name, User creator, string coverUrl, List<string> imagesUrls)
            : base(ContentCategory.Gallery, name, creator)
        {
            if (string.IsNullOrWhiteSpace(coverUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(coverUrl));

            if (imagesUrls == null)
                throw new ArgumentNullException(nameof(imagesUrls));

            CoverUrl = coverUrl;
            ImagesUrls = imagesUrls;
        }

        public virtual string CoverUrl { get; protected set; }
        public virtual List<string> ImagesUrls { get; protected set; }


        public virtual void SetCoverUrl(string coverUrl)
        {
            if (string.IsNullOrWhiteSpace(coverUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(coverUrl));

            CoverUrl = coverUrl;
        }

        public virtual void SetImagesUrls(List<string> imagesUrls)
        {
            if (imagesUrls == null)
                throw new ArgumentNullException(nameof(imagesUrls));

            ImagesUrls = imagesUrls ?? throw new ArgumentNullException(nameof(imagesUrls));
        }
    }
}
