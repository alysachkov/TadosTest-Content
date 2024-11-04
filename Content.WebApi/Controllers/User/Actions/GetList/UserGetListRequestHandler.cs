namespace Content.Controllers.User.Actions.GetList
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using AutoMapper;
    using Content.WebApi.Controllers.Country.Actions.GetList;
    using Content.WebApi.Controllers.Country.Dto;
    using Content.WebApi.Controllers.User.Actions.GetList;
    using Content.WebApi.Controllers.User.Dto;
    using Domain.Criteria;
    using Domain.Entities;
    using Pagination;
    using Queries.Abstractions;

    public class UserGetListRequestHandler : IAsyncRequestHandler<UserGetListRequest, UserGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;



        public UserGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<UserGetListResponse> ExecuteAsync(UserGetListRequest request)
        {
            List<User> users = await _asyncQueryBuilder
                .For<List<User>>()
                .WithAsync(new FindUserByFilter(
                    request.Pagination ?? null,
                    request.Filter?.Search));

            return new UserGetListResponse(
                Page: new PaginatedList<UserListItemDto>(
                    users.Count,
                    _mapper.Map<List<UserListItemDto>>(users))
                );
        }
    }
}
