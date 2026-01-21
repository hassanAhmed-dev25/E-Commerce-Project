namespace ECommerceProject.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Table
            builder.ToTable("Orders");


            // Primary Key
            builder.HasKey(o => o.Id);


            // Properties
            builder.Property(o => o.TotalAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(o => o.OrderStatus)
                   .IsRequired();

            builder.Property(o => o.PaymentStatus)
                   .IsRequired();

            builder.Property(o => o.CreatedAt)
                   .IsRequired();

            builder.Property(o => o.UserId)
                   .IsRequired();




            // Relationships
            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId);
                   

            
            builder.HasOne(o => o.ShippingAddress)
                   .WithOne(sa => sa.Order)
                   .HasForeignKey<ShippingAddress>(sa => sa.OrderId);
                   
        }
    }
}
