namespace Content.WebApi.Controllers.Country.Actions.Create
{
    using Api.Requests.Abstractions;
    using System.ComponentModel.DataAnnotations;

    public record CountryCreateRequest : IRequest<CountryCreateResponse>
    {
        [Required]
        public string Name { get; set; }
    }
}