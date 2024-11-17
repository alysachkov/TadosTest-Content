namespace Content.WebApi.Controllers.City.Actions.Edit
{
    using Api.Requests.Abstractions;
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System;
    using Domain.Entities;
    using Domain.Criteria;
    using global::Content.Domain.Exceptions;
    using NHibernate;

    public class CityEditRequestHandler : IAsyncRequestHandler<CityEditRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;



        public CityEditRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }



        public async Task ExecuteAsync(CityEditRequest request)
        {
            City city = await _asyncQueryBuilder.FindByIdAsync<City>(request.Id)
                ?? throw new ObjectNotFoundException(request.Id, nameof(city));

            long countryId = request.CountryId ?? city.Country.Id;
            string name = !string.IsNullOrWhiteSpace(request.Name) ? request.Name : city.Name;

            Country country = await _asyncQueryBuilder.FindByIdAsync<Country>(countryId);

            int existingCount = await _asyncQueryBuilder
                .For<int>()
                .WithAsync(new FindCityCountByNameAndCountry(name, country));

            if (existingCount != 0)
                throw new NameAlreadyExistsException();

            city.SetName(name);
            city.SetCountry(country);
        }
    }
}
