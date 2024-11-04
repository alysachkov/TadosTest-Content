namespace Content.Domain.Services.User
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Contexts;
    using Domain.Exceptions;
    using Criteria;
    using Entities;
    using Enums;
    using global::Commands.Abstractions;
    using Queries.Abstractions;

    public class UserService : IUserService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;



        public UserService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }



        public async Task<User> CreateUserAsync(string email, City city, CancellationToken cancellationToken = default)
        {
            await CheckIsUserWithEmailExistAsync(email, cancellationToken);

            var user = new User(email, city);

            await _commandBuilder.CreateAsync(user, cancellationToken);

            return user;
        }



        private async Task CheckIsUserWithEmailExistAsync(string email, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindUserCountByEmail(email), cancellationToken);

            if (existingCount != 0)
                throw new EmailAlreadyExistsException();
        }
    }
}