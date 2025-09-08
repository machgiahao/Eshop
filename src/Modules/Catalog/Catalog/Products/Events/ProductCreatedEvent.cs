namespace Catalog.Products.Events;

// record type is ideal for event as they are immutable and value-based
//Domain Event is just a "fact" that happened, never changes. So we use record type
public record ProductCreatedEvent(Product Product) : IDomainEvent;


