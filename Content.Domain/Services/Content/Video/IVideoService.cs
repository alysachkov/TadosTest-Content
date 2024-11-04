namespace Content.Domain.Services.Content.Video
{
    using Domain.Entities;
    using global::Domain.Abstractions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    public interface IVideoService : IDomainService
    {
        Task<Video> CreateVideoAsync(
            string name,
            User creator,
            string url,
            CancellationToken cancellationToken = default);
    }
}
