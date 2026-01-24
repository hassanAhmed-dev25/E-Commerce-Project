
namespace ECommerceProject.Infrastructure.Configurations
{
    public class WithdrawalRequestConfiguration : IEntityTypeConfiguration<WithdrawalRequest>
    {
        public void Configure(EntityTypeBuilder<WithdrawalRequest> builder)
        {
            // Table
            builder.ToTable("WithdrawalRequests");


            // Primary Key
            builder.HasKey(wr => wr.Id);



            // Properties
            builder.Property(wr => wr.Amount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

            builder.Property(wr => wr.WithdrawalStatus)
                   .IsRequired()
                   .HasConversion<string>();

            builder.Property(wr => wr.RequestedAt)
                   .IsRequired();

            builder.Property(wr => wr.ApprovedAt)
                   .IsRequired(false);

            builder.Property(wr => wr.CompletedAt)
                   .IsRequired(false);

            builder.Property(wr => wr.SellerId)
                   .IsRequired();

        }
    }
}
