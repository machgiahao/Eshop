namespace Catalog.Data;

public class CatalogDbContext: DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("catalog");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // cấu hình ModelBuilder
        // tự động tìm tất cả các class trong assembly hiện tại (ở đây là trong phạm vi catalog.dll) mà đang implement interface IEntityTypeConfiguration và apply toàn bộ các cấu hình mapping (configuration) của entity tương ứng vào ModelBuilder.
        base.OnModelCreating(builder);
    }
}
