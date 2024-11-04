namespace Content.Domain.Criteria
{
    using Entities;
    using Queries.Abstractions;

    public record FindRateCountByContentAndUser(Content Content, User User) : ICriterion;
}
