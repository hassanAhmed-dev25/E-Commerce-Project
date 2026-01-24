namespace ECommerceProject.Infrastructure.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {

            // Table
            builder.ToTable("Wallets");


            // Primary Key
            builder.HasKey(w => w.Id);



            // Properties
            builder.Property(w => w.Balance)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)");

            builder.Property(w => w.UserId)
                   .IsRequired();
        }
            
    }
}
