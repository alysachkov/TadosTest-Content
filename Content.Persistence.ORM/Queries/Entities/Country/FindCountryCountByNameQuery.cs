namespace Content.Persistence.ORM.Queries.Entities.Country
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;

    public class FindCountryCountByNameQuery :
        LinqAsyncQueryBase<Country, FindCountryCountByName, int>
    {
        public FindCountryCountByNameQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }



        public override Task<int> AskAsync(
            FindCountryCountByName criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(x => x.Name == criterion.Name, cancellationToken);
        }
    }
}