namespace ECommerceProject.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            // Configure the Product entity
            builder.ToTable("Products");

            // Primary Key
            builder.HasKey(p => p.Id);


            // Properties
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Price)
                     .IsRequired()
                     .HasColumnType("decimal(18,2)");

            builder.Property(p => p.StockQuantity)
                    .IsRequired();

            builder.Property(p => p.IsActive)
                    .HasDefaultValue(true);

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");


            // Relationships
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);

        }
    }
}
