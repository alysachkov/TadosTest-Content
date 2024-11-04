namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System;
    using Domain.Criteria;
    using Domain.Entities;
    using NHibernate;

    public class VideoEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<VideoEditHierarchicRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;



        public VideoEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }



        protected override async Task EditContentAsync(
            string name,
            VideoEditHierarchicRequest request)
        {
            Video video = await _asyncQueryBuilder.FindByIdAsync<Video>(request.Id)
                ?? throw new ObjectNotFoundException(request.Id, nameof(video));

            if (!string.IsNullOrWhiteSpace(request.Name))
                video.SetName(request.Name);

            if (!string.IsNullOrWhiteSpace(request.Url))
                video.SetUrl(request.Url);
        }
    }
}
