using Ecart.Core.Domain;

namespace Ecart.Core.Events;
public record IntegrationEvent: IDomainEvent
{
    public Guid Id => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;
    public string? EventType => GetType()?.AssemblyQualifiedName;
}
