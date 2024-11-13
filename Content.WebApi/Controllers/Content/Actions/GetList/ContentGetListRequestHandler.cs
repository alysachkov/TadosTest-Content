﻿namespace Content.WebApi.Controllers.Content.Actions.GetList
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

    public class ContentGetListRequestHandler : IAsyncRequestHandler<ContentGetListRequest, ContentGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;



        public ContentGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<ContentGetListResponse> ExecuteAsync(ContentGetListRequest request)
        {
            var (contentList, totalCount) = await _asyncQueryBuilder
                .For<(List<Content>, int)>()
                .WithAsync(new FindContentByFilter(
                    request.Pagination,
                    request.Filter?.Category,
                    request.Filter?.UserId,
                    request.Filter?.Search));

            return new ContentGetListResponse(
                Page: new PaginatedList<ContentListItemDto>(
                    totalCount,
                    _mapper.Map<List<ContentListItemDto>>(contentList))
                );
        }
    }
}
