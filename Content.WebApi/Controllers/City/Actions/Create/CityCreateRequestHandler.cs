namespace Content.WebApi.Controllers.City.Actions.Create
{
    using System;
    using System.Threading.Tasks;
    using Api.Requests.Abstractions;
    using Domain.Entities;
    using Domain.Criteria;
    using Domain.Services.City;
    using Queries.Abstractions;

    public class CityCreateRequestHandler : IAsyncRequestHandler<CityCreateRequest, CityCreateResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly ICityService _cityService;



        public CityCreateRequestHandler(ICityService cityService, IAsyncQueryBuilder asyncQueryBuilder)
        {
            _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }



        public async Task<CityCreateResponse> ExecuteAsync(CityCreateRequest request)
        {
            var country = await _asyncQueryBuilder.FindByIdAsync<Country>(request.CountryId);

            City city = await _cityService.CreateCityAsync(
                name: request.Name.Trim(),
                country: country
            );

            return new CityCreateResponse(
                Id: city.Id);
        }
    }
}
