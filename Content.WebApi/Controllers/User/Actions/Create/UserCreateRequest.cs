namespace Content.WebApi.Controllers.User.Actions.Create
{
    using Api.Requests.Abstractions;
    using System.ComponentModel.DataAnnotations;

    public record UserCreateRequest : IRequest<UserCreateResponse>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public long CityId { get; set; }
    }
}