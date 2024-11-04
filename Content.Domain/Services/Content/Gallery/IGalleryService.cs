namespace Content.Domain.Services.Content.Gallery
{
    using Domain.Entities;
    using global::Domain.Abstractions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    public interface IGalleryService : IDomainService
    {
        Task<Gallery> CreateGalleryAsync(
            string name,
            User creator,
            string coverUrl,
            List<string> imagesUrls,
            CancellationToken cancellationToken = default);
    }
}
