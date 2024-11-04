namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System;
    using Domain.Criteria;
    using Domain.Entities;
    using NHibernate;

    public class ArticleEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<ArticleEditHierarchicRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;



        public ArticleEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }



        protected override async Task EditContentAsync(
            string name,
            ArticleEditHierarchicRequest request)
        {
            Article article = await _asyncQueryBuilder.FindByIdAsync<Article>(request.Id)
                ?? throw new ObjectNotFoundException(request.Id, nameof(article));

            if (!string.IsNullOrWhiteSpace(request.Name))
                article.SetName(name);

            if (!string.IsNullOrWhiteSpace(request.Text))
                article.SetText(request.Text);
        }
    }
}
