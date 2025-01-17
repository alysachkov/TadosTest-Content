﻿namespace Content.Persistence.ORM.Queries.Entities.Content
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

    public class FindContentByFilterQuery :
        LinqAsyncQueryBase<Content, FindContentByFilter, PaginatedList<Content>>
    {
        public FindContentByFilterQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override async Task<PaginatedList<Content>> AskAsync(
            FindContentByFilter criterion,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Content> query = Query;

            if (criterion.ContentCategory.HasValue)
                query = query.Where(x => x.Category == criterion.ContentCategory.Value);

            if (criterion.UserId.HasValue)
                query = query.Where(x => x.Creator.Id == criterion.UserId.Value);

            if (!string.IsNullOrWhiteSpace(criterion.Search))
            {
                query = query
                    .Where(x => x.Name.Contains(criterion.Search) ||
                                (x as Article).Text.Contains(criterion.Search) ||
                                (x as Gallery).CoverUrl.Contains(criterion.Search) ||
                                (x as Video).Url.Contains(criterion.Search));
            }

            var totalCount = await ToAsync(query).CountAsync(cancellationToken);

            query = query.OrderBy(x => x.Name);

            if (criterion.Pagination != null)
                query = query.Skip(criterion.Pagination.Offset).Take(criterion.Pagination.Count);

            var queryList = await ToAsync(query).ToListAsync(cancellationToken);

            return new PaginatedList<Content>(totalCount, queryList);
        }
    }
}