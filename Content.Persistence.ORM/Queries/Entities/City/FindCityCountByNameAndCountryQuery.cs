namespace Content.Persistence.ORM.Queries.Entities.City
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;

    public class FindCityCountByNameAndCountryQuery :
        LinqAsyncQueryBase<City, FindCityCountByNameAndCountry, int>
    {
        public FindCityCountByNameAndCountryQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }



        public override Task<int> AskAsync(
            FindCityCountByNameAndCountry criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(
                x => x.Name == criterion.Name && x.Country == criterion.Country,
                cancellationToken);
        }
    }
}