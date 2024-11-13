namespace Content.Domain.ValueObjects
{
    using global::Domain.Abstractions;
    using System;
    using Content.Domain.Entities;


    public class ImageUrl : IValueObjectWithId
    {
        [Obsolete("Only for reflection", true)]
        public ImageUrl() { }

        public ImageUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(url));

            Url = url;
        }
        public virtual long Id { get; init; }
        public virtual string Url { get; init; }
    }
}
