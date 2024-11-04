namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System;
    using global::Content.Domain.Entities;
    using global::Content.Domain.Services.Content.Gallery;

    public class GalleryCreateHierarchicRequestHandler : ContentCreateHierarchicRequestHandler<GalleryCreateHierarchicRequest>
    {
        private readonly IGalleryService _galleryService;



        public GalleryCreateHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IGalleryService galleryService)
            : base(asyncQueryBuilder)
        {
            _galleryService = galleryService ?? throw new ArgumentNullException(nameof(galleryService));
        }



        protected override async Task<Content> CreateContentAsync(
            string name,
            User creator,
            GalleryCreateHierarchicRequest request)
        {
            Gallery gallery = await _galleryService.CreateGalleryAsync(
                name: name,
                creator: creator,
                coverUrl: request.CoverUrl,
                imagesUrls: request.ImagesUrls);

            return gallery;
        }
    }
}
