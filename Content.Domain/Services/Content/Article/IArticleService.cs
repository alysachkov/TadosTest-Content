namespace Content.Domain.Services.Content.Article
{
    using Domain.Entities;
    using global::Domain.Abstractions;
    using System.Threading;
    using System.Threading.Tasks;
    public interface IArticleService : IDomainService
    {
        Task<Article> CreateArticleAsync(
            string name,
            User creator,
            string text,
            CancellationToken cancellationToken = default);
    }
}
