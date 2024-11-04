namespace Content.WebApi.Controllers.Country.Dto
{
    public record CountryListItemDto
    {
        public long Id { get; init; }

        public string Name { get; init; }
    }
}