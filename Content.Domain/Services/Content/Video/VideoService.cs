namespace Content.Domain.Services.Content.Video
{
    using global::Commands.Abstractions;
    using global::Content.Domain.Entities;
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    public class VideoService : ContentServiceBase, IVideoService
    {
        public VideoService(
            IAsyncQueryBuilder asyncQueryBuilder,
            IAsyncCommandBuilder asyncCommandBuilder)
            : base(
                  asyncQueryBuilder,
                  asyncCommandBuilder)
        {
        }

        public async Task<Video> CreateVideoAsync(
            string name,
            User creator,
            string url,
            CancellationToken cancellationToken = default)
        {
            var video = new Video(name, creator, url);

            await CreateContentAsync(video, cancellationToken);

            return video;
        }
    }
}
