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
            if (rating <= 0 || rating > 5)
                throw new ArgumentOutOfRangeException(nameof(rating));

            Content = content ?? throw new ArgumentNullException(nameof(user));
            User = user ?? throw new ArgumentNullException(nameof(user));
            Rating = rating;
        }
        public virtual long Id { get; init; }
        public virtual Content Content { get; init; }
        public virtual User User { get; init; }
        public virtual int Rating { get; init; }
    }
}
