namespace Content.Domain.Exceptions
{
    using System;
    using global::Domain.Abstractions;

    public class RateAlreadyExistsException : Exception, IDomainException
    {
        private const string DefaultMessage = "Rate already exists";



        public RateAlreadyExistsException()
            : base(DefaultMessage)
        {
        }
    }
}
