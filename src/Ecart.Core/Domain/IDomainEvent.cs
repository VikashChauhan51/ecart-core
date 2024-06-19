using MediatR;

namespace Ecart.Core.Domain;
public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;
    public string? EventType => this.GetType()?.AssemblyQualifiedName;
}
