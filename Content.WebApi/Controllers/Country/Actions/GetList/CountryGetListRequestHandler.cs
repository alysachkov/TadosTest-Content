﻿namespace Content.WebApi.Controllers.Country.Actions.GetList
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

    public class CountryGetListRequestHandler : IAsyncRequestHandler<CountryGetListRequest, CountryGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;



        public CountryGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<CountryGetListResponse> ExecuteAsync(CountryGetListRequest request)
        {
            PaginatedList<Country> countries = await _asyncQueryBuilder
                .For<PaginatedList<Country>>()
                .WithAsync(new FindCountryByFilter(
                    request.Pagination,
                    request.Filter?.Search));

            return new CountryGetListResponse(
                Page: new PaginatedList<CountryListItemDto>(
                    countries.TotalCount,
                    _mapper.Map<List<CountryListItemDto>>(countries.Items))
                );
        }
    }
}
