namespace Content.WebApi.Controllers.Country.Actions.Edit
{
    using Api.Requests.Abstractions;
    using System.ComponentModel.DataAnnotations;

    public record CountryEditRequest : IRequest
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}