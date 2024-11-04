namespace Content.Persistence.ORM.Queries.Entities.Content
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Criteria;
    using Domain.Entities;
    using Linq.AsyncQueryable.Abstractions.Factories;
    using Linq.Providers.Abstractions;

    public class FindContentCountByNameAndContentCategoryQuery :
        LinqAsyncQueryBase<Content, FindContentCountByNameAndContentCategory, int>
    {
        public FindContentCountByNameAndContentCategoryQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }



        public override Task<int> AskAsync(
            FindContentCountByNameAndContentCategory criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(
                x => x.Name == criterion.Name && x.Category == criterion.ContentCategory,
                cancellationToken);
        }
    }
}