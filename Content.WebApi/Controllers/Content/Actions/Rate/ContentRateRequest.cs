namespace Content.WebApi.Controllers.Content.Actions.Rate
{
    using Api.Requests.Abstractions;
    using System.ComponentModel.DataAnnotations;

    public record ContentRateRequest : IRequest
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public long ContentId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
    }
}