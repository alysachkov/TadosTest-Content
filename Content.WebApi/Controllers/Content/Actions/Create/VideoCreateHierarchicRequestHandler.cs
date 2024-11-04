namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System;
    using global::Content.Domain.Entities;
    using global::Content.Domain.Services.Content.Video;

    public class VideoCreateHierarchicRequestHandler : ContentCreateHierarchicRequestHandler<VideoCreateHierarchicRequest>
    {
        private readonly IVideoService _videoService;



        public VideoCreateHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IVideoService videoService)
            : base(asyncQueryBuilder)
        {
            _videoService = videoService ?? throw new ArgumentNullException(nameof(videoService));
        }



        protected override async Task<Content> CreateContentAsync(
            string name,
            User creator,
            VideoCreateHierarchicRequest request)
        {
            Video video = await _videoService.CreateVideoAsync(
                name: name,
                creator: creator,
                url: request.Url);

            return video;
        }
    }
}
