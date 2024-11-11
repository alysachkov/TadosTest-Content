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
            Email = email ?? throw new ArgumentNullException(nameof(email));
            SetCity(city);
        }

        public virtual long Id { get; init; }
        public virtual string Email { get; protected set; }
        public virtual City City { get; protected set; }

        public virtual void SetCity(City city)
        {
            City = city ?? throw new ArgumentNullException(nameof(city));
        }
    }
}
