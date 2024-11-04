namespace Content.WebApi.Controllers.Country.Actions.Edit
{
    using Api.Requests.Abstractions;
    using Queries.Abstractions;
    using System.Threading.Tasks;
    using System;
    using Domain.Entities;
    using Domain.Criteria;
    using Microsoft.AspNetCore.Http.Extensions;
    using System.Threading;
    using System.Xml.Linq;
    using global::Content.Domain.Exceptions;
    using NHibernate;

    public class CountryEditRequestHandler : IAsyncRequestHandler<CountryEditRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;



        public CountryEditRequestHandler(IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
        }



        public async Task ExecuteAsync(CountryEditRequest request)
        {
            Country country = await _asyncQueryBuilder.FindByIdAsync<Country>(request.Id)
                ?? throw new ObjectNotFoundException(request.Id, nameof(country));

            int existingCount = await _asyncQueryBuilder
                .For<int>()
                .WithAsync(new FindCountryCountByName(request.Name));

            if (existingCount != 0)
                throw new NameAlreadyExistsException();

            country.SetName(request.Name);
        }       
    }
}
