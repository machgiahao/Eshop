namespace Catalog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(Guid.NewGuid(), "Iphone X", ["category1"], "Long description", "imageFile", 500),
            Product.Create(Guid.NewGuid(), "Samsung 10", ["category1"], "Long description", "imageFile", 400),
            Product.Create(Guid.NewGuid(), "Huawei Plus", ["category2"], "Long description", "imageFile", 600),
            Product.Create(Guid.NewGuid(), "Xiaomi", ["category2"], "Long description", "imageFile", 450),
        };
}
