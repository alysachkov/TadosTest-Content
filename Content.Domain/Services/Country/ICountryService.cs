﻿namespace Content.Domain.Services.Country
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using global::Domain.Abstractions;

    public interface ICountryService : IDomainService
    {
        Task<Country> CreateCountryAsync(string name, CancellationToken cancellationToken = default);
    }
}