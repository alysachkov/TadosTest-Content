namespace Content.Persistence.ORM.Queries.Entities.User
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Queries;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;


    public class FindUserByFilterQuery :
        LinqAsyncQueryBase<User, FindUserByFilter, List<User>>
    {
        public FindUserByFilterQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override Task<List<User>> AskAsync(
            FindUserByFilter criterion,
            CancellationToken cancellationToken = default)
        {
            IQueryable<User> query = Query;

            if (!string.IsNullOrWhiteSpace(criterion.Search))
                query = query.Where(x => x.Email.Contains(criterion.Search));

            if (criterion.Pagination != null)
                query = query.Skip(criterion.Pagination.Offset).Take(criterion.Pagination.Count);

            query = query.OrderBy(x => x.Email);

            return ToAsync(query).ToListAsync(cancellationToken);
        }
    }
}