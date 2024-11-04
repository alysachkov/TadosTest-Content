namespace Content.Domain.Services.Country
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

    public class CountryService : ICountryService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;



        public CountryService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }



        public async Task<Country> CreateCountryAsync(string name, CancellationToken cancellationToken = default)
        {
            await CheckIsCountryWithNameExistAsync(name, cancellationToken);

            var country = new Country(name);

            await _commandBuilder.CreateAsync(country, cancellationToken);

            return country;
        }



        private async Task CheckIsCountryWithNameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindCountryCountByName(name), cancellationToken);

            if (existingCount != 0)
                throw new NameAlreadyExistsException();
        }
    }
}