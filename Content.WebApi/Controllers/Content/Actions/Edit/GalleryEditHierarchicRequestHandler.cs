namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System;
    using Domain.Criteria;
    using Domain.Entities;
    using NHibernate;

    public class GalleryEditHierarchicRequestHandler : ContentEditHierarchicRequestHandler<GalleryEditHierarchicRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;



        public GalleryEditHierarchicRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }



        protected override async Task EditContentAsync(
            string name,
            GalleryEditHierarchicRequest request)
        {
            Gallery gallery = await _asyncQueryBuilder.FindByIdAsync<Gallery>(request.Id)
                ?? throw new ObjectNotFoundException(request.Id, nameof(gallery));

            if (!string.IsNullOrWhiteSpace(request.Name))
                gallery.SetName(request.Name);

            if (!string.IsNullOrWhiteSpace(request.CoverUrl))
                gallery.SetCoverUrl(request.CoverUrl);

            if (request.ImagesUrls != null)
                gallery.SetImagesUrls(request.ImagesUrls);
        }
    }
}
