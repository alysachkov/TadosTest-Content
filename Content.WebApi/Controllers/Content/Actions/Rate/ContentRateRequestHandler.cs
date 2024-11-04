namespace Content.WebApi.Controllers.Content.Actions.Rate
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using Domain.Services.Rate;
    using Domain.Entities;
    using Queries.Abstractions;
    using Domain.Criteria;

    public class ContentRateRequestHandler : IAsyncRequestHandler<ContentRateRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IRateService _rateService;



        public ContentRateRequestHandler(IRateService rateService, IAsyncQueryBuilder asyncQueryBuilder)
        {
            _rateService = rateService ?? throw new ArgumentNullException(nameof(rateService));
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }
        public async Task ExecuteAsync(ContentRateRequest request)
        {
            Content content = await _asyncQueryBuilder.FindByIdAsync<Content>(request.ContentId);
            User user = await _asyncQueryBuilder.FindByIdAsync<User>(request.UserId);

            await _rateService.CreateRateAsync(
                content: content,
                user: user,
                rating: request.Rate
            );
        }
    }
}
