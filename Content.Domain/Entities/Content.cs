namespace Content.Domain.Entities
{
    using Enums;
    using global::Domain.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Content : IEntity
    {
        private readonly ICollection<Rate> _ratings = new HashSet<Rate>();

        [Obsolete("Only for reflection", true)]
        public Content() { }

        protected Content(ContentCategory category, string name, User creator)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            if (creator == null)
                throw new ArgumentNullException(nameof(creator));

            Category = category;
            Name = name;
            Creator = creator;
        }

        public virtual long Id { get; init; }
        public virtual ContentCategory Category { get; init; }
        public virtual string Name { get; protected set; }
        public virtual User Creator { get; init; }

        public virtual IEnumerable<Rate> Ratings => _ratings;
        public virtual double AverageRating =>
            _ratings?.Any() == true ? _ratings.AsQueryable().Average(x => x.Rating) : 0;


        public virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
        }
    }
}
