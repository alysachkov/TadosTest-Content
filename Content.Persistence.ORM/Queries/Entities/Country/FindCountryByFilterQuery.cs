﻿namespace Content.Persistence.ORM.Queries.Entities.Country
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Queries;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;
    using Pagination;

    public class FindCountryByFilterQuery :
        LinqAsyncQueryBase<Country, FindCountryByFilter, PaginatedList<Country>>
    {
        public FindCountryByFilterQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override async Task<PaginatedList<Country>> AskAsync(
            FindCountryByFilter criterion,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Country> query = Query;

            if (!string.IsNullOrWhiteSpace(criterion.Search))
                query = query.Where(x => x.Name.Contains(criterion.Search));

            var totalCount = await ToAsync(query).CountAsync(cancellationToken);

            query = query.OrderBy(x => x.Name);

            if (criterion.Pagination != null)
                query = query.Skip(criterion.Pagination.Offset).Take(criterion.Pagination.Count);

            var queryList = await ToAsync(query).ToListAsync(cancellationToken);

            return new PaginatedList<Country>(totalCount, queryList);
        }
    }
}