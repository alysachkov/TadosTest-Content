namespace Content.WebApi.Controllers.User.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using Domain.Entities;
    using Domain.Services.User;
    using Queries.Abstractions;
    using Domain.Criteria;

    public class UserCreateRequestHandler : IAsyncRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IUserService _userService;



        public UserCreateRequestHandler(IUserService userService, IAsyncQueryBuilder asyncQueryBuilder)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }



        public async Task<UserCreateResponse> ExecuteAsync(UserCreateRequest request)
        {
            var city = await _asyncQueryBuilder.FindByIdAsync<City>(request.CityId);

            User user = await _userService.CreateUserAsync(
                email: request.Email.Trim(),
                city: city
            );

            return new UserCreateResponse(
                Id: user.Id);
        }
    }
}
