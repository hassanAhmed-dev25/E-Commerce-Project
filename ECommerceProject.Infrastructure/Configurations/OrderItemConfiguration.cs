namespace ECommerceProject.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Table
            builder.ToTable("OrderItems");


            // Primary Key
            builder.HasKey(oi => oi.Id);



            // Properties
            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            builder.Property(oi => oi.UnitPrice)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(oi => oi.OrderId)
                   .IsRequired();

            builder.Property(oi => oi.ProductId)
                   .IsRequired();

            builder.Property(oi => oi.SellerId)
                   .IsRequired();




            // Relationships  
            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId);

            
            builder.HasOne(oi => oi.Product)
                   .WithMany()
                   .HasForeignKey(oi => oi.ProductId);
        }
    }
}
