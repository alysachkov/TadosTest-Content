namespace Content.Persistence.ORM.Queries.Entities.User
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;

    public class FindUserCountByEmailQuery :
        LinqAsyncQueryBase<User, FindUserCountByEmail, int>
    {
        public FindUserCountByEmailQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }



        public override Task<int> AskAsync(
            FindUserCountByEmail criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(x => x.Email == criterion.Email, cancellationToken);
        }
    }
}