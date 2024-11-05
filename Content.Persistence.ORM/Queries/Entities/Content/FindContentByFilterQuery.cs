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

            List<Content> combinedResults = new();

            if (!string.IsNullOrWhiteSpace(criterion.Search))
            {
                var contentResults = query
                    .Where(x => x.Name.Contains(criterion.Search))
                    .ToList();

                var articleResults = query
                    .OfType<Article>()
                    .Where(x => x.Text.Contains(criterion.Search))
                    .ToList();

                var galleryResults = query
                    .OfType<Gallery>()
                    .Where(x => x.CoverUrl.Contains(criterion.Search) ||
                                x.ImagesUrls.ToString().Contains(criterion.Search))
                    .ToList();

                var videoResults = query
                    .OfType<Video>()
                    .Where(x => x.Url.Contains(criterion.Search))
                    .ToList();

                combinedResults = contentResults
                    .Concat(articleResults)
                    .Concat(galleryResults)
                    .Concat(videoResults)
                    .Distinct()
                    .ToList();
            }
            else
            {
                combinedResults = query.ToList();
            }

            if (criterion.Pagination != null)
                combinedResults = combinedResults
                    .Skip(criterion.Pagination.Offset)
                    .Take(criterion.Pagination.Count)
                    .ToList();

            combinedResults = combinedResults
                .OrderBy(x => x.Name)
                .ToList();

            return Task.FromResult(combinedResults);
        }
    }
}