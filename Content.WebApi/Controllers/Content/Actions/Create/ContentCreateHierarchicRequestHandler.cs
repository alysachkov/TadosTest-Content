namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Hierarchic.Abstractions;
    using Domain.Criteria;
    using Domain.Entities;
    using Queries.Abstractions;

    public abstract class ContentCreateHierarchicRequestHandler<TConcreteContentHierarchicRequest> : AsyncHierarchicRequestHandlerBase<TConcreteContentHierarchicRequest, ContentCreateHierarchicResponse>
        where TConcreteContentHierarchicRequest: ContentCreateHierarchicRequest
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;



        protected ContentCreateHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }



        protected override async Task<ContentCreateHierarchicResponse> ExecuteAsync(TConcreteContentHierarchicRequest request)
        {
            var user = await _asyncQueryBuilder.FindByIdAsync<User>(request.UserId);

            Content content = await CreateContentAsync(
                name: request.Name.Trim(),
                creator: user,
                request: request);

            return new ContentCreateHierarchicResponse(
                Id: content.Id);
        }



        protected abstract Task<Content> CreateContentAsync(
            string name, 
            User creator, 
            TConcreteContentHierarchicRequest request);
    }
}