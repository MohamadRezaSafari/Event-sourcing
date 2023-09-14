using Catalog.Domain.Entities.Common;

namespace Catalog.Application.Common.Interfaces;

public interface IAggregateRepository
{
    public interface IAggregateRepository<TA, TKey> where TA : class, IAggregateRoot<TKey>
    {
        // Append events to store in event store database
        Task AppendAsync(TA aggregate,
            CancellationToken cancellationToken = default);

        // Read all events using aggregate ID
        Task<TA?> RehydrateAsync(TKey aggregateId,
            CancellationToken cancellationToken = default);

        // Read events as a log and return into a dictionary
        Task<Dictionary<int, object>> ReadEventsAsync(TKey aggregateId,
            CancellationToken cancellationToken = default);
    }
}