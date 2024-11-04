namespace Content.Persistence.ORM.Queries.Entities.Rate
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;

    public class FindRateCountByContentAndUserQuery :
        LinqAsyncQueryBase<Rate, FindRateCountByContentAndUser, int>
    {
        public FindRateCountByContentAndUserQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }



        public override Task<int> AskAsync(
            FindRateCountByContentAndUser criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(
                x => x.Content == criterion.Content && x.User == criterion.User,
                cancellationToken);
        }
    }
}