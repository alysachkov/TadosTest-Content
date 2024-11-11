namespace Content.Domain.Entities
{
    using global::Domain.Abstractions;
    using System;
    using System.Reflection.Metadata;
    using System.Xml.Linq;

    public class ImageUrl : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public ImageUrl() { }

        public ImageUrl(string url, Gallery gallery)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(url));

            Url = url;
            Gallery = gallery ?? throw new ArgumentNullException(nameof(gallery));
        }
        public virtual long Id { get; init; }
        public virtual string Url { get; init; }
        public virtual Gallery Gallery { get; init; }
    }
}
