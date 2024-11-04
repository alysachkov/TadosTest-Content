namespace Content.Domain.Services.Content
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Contexts;
    using Criteria;
    using Entities;
    using Enums;
    using Exceptions;
    using global::Commands.Abstractions;
    using Queries.Abstractions;

    public abstract class ContentServiceBase
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IAsyncCommandBuilder _asyncCommandBuilder;



        protected ContentServiceBase(IAsyncQueryBuilder asyncQueryBuilder, IAsyncCommandBuilder asyncCommandBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _asyncCommandBuilder = asyncCommandBuilder ?? throw new ArgumentNullException(nameof(asyncCommandBuilder));
        }



        protected async Task CreateContentAsync<TContent>(
            TContent content,
            CancellationToken cancellationToken = default)
            where TContent : Content, new()
        {
            await CheckIsContentWithNameExistAsync(content.Category, content.Name, cancellationToken);

            await _asyncCommandBuilder.CreateAsync(content, cancellationToken);
        }



        private async Task CheckIsContentWithNameExistAsync(
            ContentCategory contentCategory,
            string name,
            CancellationToken cancellationToken = default)
        {
            int existingCount = await _asyncQueryBuilder
                .For<int>()
                .WithAsync(
                    new FindContentCountByNameAndContentCategory(name, contentCategory),
                    cancellationToken);

            if (existingCount != 0)
                throw new NameAlreadyExistsException();
        }
    }
}
