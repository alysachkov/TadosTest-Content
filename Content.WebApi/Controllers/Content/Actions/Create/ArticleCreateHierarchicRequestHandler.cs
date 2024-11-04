namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System;
    using Domain.Services.Content.Article;
    using global::Content.Domain.Entities;

    public class ArticleCreateHierarchicRequestHandler : ContentCreateHierarchicRequestHandler<ArticleCreateHierarchicRequest>
    {
        private readonly IArticleService _articleService;



        public ArticleCreateHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IArticleService articleService)
            : base(asyncQueryBuilder)
        {
            _articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
        }



        protected override async Task<Content> CreateContentAsync(
            string name,
            User creator,
            ArticleCreateHierarchicRequest request)
        {
            Article article = await _articleService.CreateArticleAsync(
                name: name,
                creator: creator,
                text: request.Text);

            return article;
        }
    }
}
