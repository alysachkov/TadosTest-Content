namespace Content.WebApi.Controllers.City.Actions.GetList
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using AutoMapper;
    using Domain.Criteria;
    using Domain.Entities;
    using Dto;
    using Pagination;
    using Queries.Abstractions;

    public class CityGetListRequestHandler : IAsyncRequestHandler<CityGetListRequest, CityGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;



        public CityGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<CityGetListResponse> ExecuteAsync(CityGetListRequest request)
        {
            List<City> cities = await _asyncQueryBuilder
                .For<List<City>>()
                .WithAsync(new FindCityByFilter(
                    request.Pagination ?? null,
                    request.Filter?.CountryId,
                    request.Filter?.Search));

            return new CityGetListResponse(
                Page: new PaginatedList<CityListItemDto>(
                    cities.Count,
                    _mapper.Map<List<CityListItemDto>>(cities))
                );
        }
    }
}
