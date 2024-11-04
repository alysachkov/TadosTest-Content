namespace Content.Domain.Entities
{
    using global::Domain.Abstractions;
    using System;

    public class User : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public User() { }

        protected internal User(string email, City city)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(email));

            if (city == null)
                throw new ArgumentNullException(nameof(city));

            Email = email;
            City = city;
        }

        public virtual long Id { get; init; }
        public virtual string Email { get; protected set; }
        public virtual City City { get; protected set; }

        public virtual void SetCity(City city)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));

            City = city;
        }
    }
}
