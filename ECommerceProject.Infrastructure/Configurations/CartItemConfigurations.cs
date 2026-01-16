
namespace ECommerceProject.Infrastructure.Configurations
{
    public class CartItemConfigurations : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            // Configure the CartItem entity
            builder.ToTable("CartItems");


            // Primary Key
            builder.HasKey(ci => ci.Id);


            // Properties
            builder.Property(ci => ci.Quantity)
                               .IsRequired();


            builder.Property(ci => ci.UnitPrice)
                              .IsRequired();



            // Relationships
            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(ci => ci.CartId);

            builder.HasOne(ci => ci.Product)
                   .WithMany(p => p.CartItems)
                   .HasForeignKey(ci => ci.ProductId);


        }
    }
}
