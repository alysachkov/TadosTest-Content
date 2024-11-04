namespace Content.Domain.Entities
{
    using global::Domain.Abstractions;
    using System;

    public class City : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public City() { }

        public City(string name, Country country)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            if (country == null)
                throw new ArgumentNullException(nameof(country));

            Name = name;
            Country = country;
        }
        public virtual long Id { get; init; }
        public virtual string Name { get; protected set; }
        public virtual Country Country { get; protected set; }

        public virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
        }
        public virtual void SetCountry(Country country)
        {
            if (country == null)
                throw new ArgumentNullException(nameof(country));

            Country = country;
        }
    }
}
