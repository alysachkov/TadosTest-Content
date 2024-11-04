namespace Content.Domain.Services.Rate
{
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using global::Domain.Abstractions;

    public interface IRateService : IDomainService
    {
        Task<Rate> CreateRateAsync(Content content, User user, int rating, CancellationToken cancellationToken = default);
    }
}