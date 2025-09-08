namespace Catalog.Products.Models;

public class Product: Aggregate<Guid>
{
    public string Name { get; private set; } = default!; // Set private set for ensure that can only modified through the control method
    public List<string> Category { get; private set; } = new();
    public string Description { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public decimal Price { get; private set; }

    // Add a create method for initializing Product entities
    public static Product Create(Guid id, string name, List<string> category, string description, string imageFile, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product
        {
            Id = id,
            Name = name,
            Category = category,
            Description = description,
            ImageFile = imageFile,
            Price = price,
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }

    // Add an Update method for modifying Product entities
    public void Update(string name, List<string> category, string description, string imageFile, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        // Update Product entity fields
        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;
        LastModified = DateTime.UtcNow;

        // If price has changed, raise ProductPriceChanged domain event
        if(Price != price)
        {
            AddDomainEvent(new ProductPriceChangedEvent(this));
        }
    }


}

