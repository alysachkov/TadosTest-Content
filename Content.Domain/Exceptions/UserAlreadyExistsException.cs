namespace Content.Domain.Exceptions
{
    using System;
    using global::Domain.Abstractions;

    public class EmailAlreadyExistsException : Exception, IDomainException
    {
        private const string DefaultMessage = "Email already exists";



        public EmailAlreadyExistsException()
            : base(DefaultMessage)
        {
        }
    }
}
