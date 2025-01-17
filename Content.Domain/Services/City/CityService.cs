﻿namespace Content.Domain.Services.City
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

    public class CityService : ICityService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;



        public CityService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }



        public async Task<City> CreateCityAsync(string name, Country country, CancellationToken cancellationToken = default)
        {
            await CheckIsCityWithNameAndCountryExistAsync(name, country, cancellationToken);

            var city = new City(name, country);

            await _commandBuilder.CreateAsync(city, cancellationToken);

            return city;
        }



        private async Task CheckIsCityWithNameAndCountryExistAsync(string name, Country country, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindCityCountByNameAndCountry(name, country), cancellationToken);

            if (existingCount != 0)
                throw new NameAlreadyExistsException();
        }
    }
}