
namespace ECommerceProject.Infrastructure.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {

        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            // Configure the Cart entity
            builder.ToTable("Carts");


            // Primary Key
            builder.HasKey(c => c.Id);


            // Properties
            builder.Property(c => c.CreatedAt)
                               .HasDefaultValueSql("GETUTCDATE()");


            builder.Property(c => c.UserId)
                   .IsRequired();

            builder.HasIndex(c => c.UserId)
                   .IsUnique();


            // Relationships
            builder.HasMany(c => c.CartItems)
                   .WithOne(ci => ci.Cart)
                   .HasForeignKey(ci => ci.CartId);

        }
    }
}
