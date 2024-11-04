namespace Content.Domain.Entities
{
    using global::Domain.Abstractions;
    using System;

    public class Rate : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public Rate() { }

        public Rate(Content content, User user, int rating)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (user == null)
                throw new ArgumentNullException(nameof(content));

            if (rating <= 0 || rating > 5)
                throw new ArgumentOutOfRangeException(nameof(rating));

            Content = content;
            User = user;
            Rating = rating;
        }
        public virtual long Id { get; init; }
        public virtual Content Content { get; init; }
        public virtual User User { get; init; }
        public virtual int Rating { get; protected set; }
    }
}
