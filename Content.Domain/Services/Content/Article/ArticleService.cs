namespace Content.Domain.Services.Content.Article
{
    using global::Commands.Abstractions;
    using global::Content.Domain.Entities;
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System.Threading;

    public class ArticleService : ContentServiceBase, IArticleService
    {
        public ArticleService(
            IAsyncQueryBuilder asyncQueryBuilder,
            IAsyncCommandBuilder asyncCommandBuilder)
            : base(
                  asyncQueryBuilder,
                  asyncCommandBuilder)
        {
        }

        public async Task<Article> CreateArticleAsync(
            string name,
            User creator,
            string text,
            CancellationToken cancellationToken = default)
        {
            var article = new Article(name, creator, text);

            await CreateContentAsync(article, cancellationToken);

            return article;
        }
    }
}
