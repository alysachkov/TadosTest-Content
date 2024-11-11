namespace Content.Domain.Entities
{
    using global::Domain.Abstractions;
    using System;

    public class Country : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public Country() { }

        public Country(string name)
        {
            SetName(name);
        }
        public virtual long Id { get; init; }
        public virtual string Name { get; protected set; }

        public virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
        }
    }
}
