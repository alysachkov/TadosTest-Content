namespace Content.Domain.Services.Content.Gallery
{
    using global::Commands.Abstractions;
    using global::Content.Domain.Entities;
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    public class GalleryService : ContentServiceBase, IGalleryService
    {
        public GalleryService(
            IAsyncQueryBuilder asyncQueryBuilder,
            IAsyncCommandBuilder asyncCommandBuilder)
            : base(
                  asyncQueryBuilder,
                  asyncCommandBuilder)
        {
        }

        public async Task<Gallery> CreateGalleryAsync(
            string name,
            User creator,
            string coverUrl,
            List<string> imagesUrls,
            CancellationToken cancellationToken = default)
        {
            var gallery = new Gallery(name, creator, coverUrl, imagesUrls);

            await CreateContentAsync(gallery, cancellationToken);

            return gallery;
        }
    }
}
