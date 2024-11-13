namespace Content.WebApi.Controllers.Content.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using Dto;

    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, ContentListItemDto>()
                .Include<Article, ArticleListItemDto>()
                .Include<Gallery, GalleryListItemDto>()
                .Include<Video, VideoListItemDto>();

            CreateMap<Article, ArticleListItemDto>();
            CreateMap<Gallery, GalleryListItemDto>();
            CreateMap<Video, VideoListItemDto>();

            CreateMap<Content, ContentDto>()
                .Include<Article, ArticleDto>()
                .Include<Gallery, GalleryDto>()
                .Include<Video, VideoDto>();

            CreateMap<Article, ArticleDto>();
            CreateMap<Gallery, GalleryDto>();
            CreateMap<Video, VideoDto>();
        }
    }
}
