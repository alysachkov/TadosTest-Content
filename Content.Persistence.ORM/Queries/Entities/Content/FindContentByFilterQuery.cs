namespace Content.Persistence.ORM.Queries.Entities.Content
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


    public class FindContentByFilterQuery :
        LinqAsyncQueryBase<Content, FindContentByFilter, List<Content>>
    {
        public FindContentByFilterQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override Task<List<Content>> AskAsync(
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
                var contentQuery = query
                    .Where(x => x.Name.Contains(criterion.Search));

                var articleQuery = query
                    .OfType<Article>()
                    .Where(x => x.Text.Contains(criterion.Search));

                var galleryQuery = query
                    .OfType<Gallery>()
                    .Where(x => x.CoverUrl.Contains(criterion.Search) ||
                                x.ImagesUrls.Contains(criterion.Search));

                var videoQuery = query
                    .OfType<Video>()
                    .Where(x => x.Url.Contains(criterion.Search));
            }

            if (criterion.Pagination != null)
                query = query.Skip(criterion.Pagination.Offset).Take(criterion.Pagination.Count);

            query = query.OrderBy(x => x.Name);

            return ToAsync(query).ToListAsync(cancellationToken);
        }
    }
}