namespace ECommerceProject.Infrastructure.Configurations
{
    public class ShippingAddressConfiguration : IEntityTypeConfiguration<ShippingAddress>
    {
        public void Configure(EntityTypeBuilder<ShippingAddress> builder)
        {
            // Table
            builder.ToTable("ShippingAddresses");


            // Primary Key
            builder.HasKey(sa => sa.Id);



            // Properties
            builder.Property(sa => sa.Address)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(sa => sa.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(sa => sa.Street)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(sa => sa.Apartment)
                   .HasMaxLength(50);

            builder.Property(sa => sa.OrderId)
                   .IsRequired();



            // Relationships
            builder.HasOne(sa => sa.Order)
                   .WithOne(o => o.ShippingAddress)
                   .HasForeignKey<ShippingAddress>(sa => sa.OrderId);
        }
    }
}
