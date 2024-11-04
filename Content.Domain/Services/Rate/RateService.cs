namespace Content.Domain.Services.Rate
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Contexts;
    using Domain.Exceptions;
    using Criteria;
    using Entities;
    using global::Commands.Abstractions;
    using Queries.Abstractions;

    public class RateService : IRateService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;



        public RateService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }



        public async Task<Rate> CreateRateAsync(Content content, User user, int rating, CancellationToken cancellationToken = default)
        {
            await CheckIsRateWithContentAndUserExistAsync(content, user, cancellationToken);

            var rate = new Rate(content, user, rating);

            await _commandBuilder.CreateAsync(rate, cancellationToken);

            return rate;
        }



        private async Task CheckIsRateWithContentAndUserExistAsync(Content content, User user, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindRateCountByContentAndUser(content, user), cancellationToken);

            if (existingCount != 0)
                throw new RateAlreadyExistsException();
        }
    }
}