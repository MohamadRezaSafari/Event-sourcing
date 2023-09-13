namespace Catalog.Domain.Entities.Common;

public class BaseDomainEvent<TA, TKey> : IDomainEvent<TKey>
    where TA : IAggregateRoot<TKey>
{
    protected BaseDomainEvent()
    {
    }

    public BaseDomainEvent(TA aggregateRoot)
    {
        if (aggregateRoot is null)
        {
            throw new ArgumentNullException(nameof(aggregateRoot));
        }

        AggregateId = aggregateRoot.Id;
        AggregateVersion = aggregateRoot.Version;
        TimeStamp = DateTime.Now;
    }

    public long AggregateVersion { get; private set; }
    public TKey AggregateId { get; private set; }
    public DateTime TimeStamp { get; private set; }
}