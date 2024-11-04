namespace Content.WebApi.Controllers.User.Actions.Edit
{
    using Api.Requests.Abstractions;
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System;
    using Domain.Entities;
    using Domain.Criteria;
    using global::Content.Domain.Exceptions;
    using NHibernate;

    public class UserEditRequestHandler : IAsyncRequestHandler<UserEditRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;



        public UserEditRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }



        public async Task ExecuteAsync(UserEditRequest request)
        {
            User user = await _asyncQueryBuilder.FindByIdAsync<User>(request.Id)
                ?? throw new ObjectNotFoundException(request.Id, nameof(user));

            City city = await _asyncQueryBuilder.FindByIdAsync<City>(request.CityId)
                ?? throw new ObjectNotFoundException(request.Id, nameof(city));

            user.SetCity(city);
        }
    }
}
