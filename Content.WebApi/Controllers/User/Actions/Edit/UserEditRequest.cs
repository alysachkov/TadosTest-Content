using Api.Requests.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Content.WebApi.Controllers.User.Actions.Edit
{
    public record UserEditRequest : IRequest
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public long CityId { get; set; }
    }
}