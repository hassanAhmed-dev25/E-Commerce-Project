namespace ECommerceProject.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Configure the Category entity
            builder.ToTable("Categories");
            

            // Primary Key
            builder.HasKey(c => c.Id);


            // Properties
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);


            builder.Property(c => c.Description)
                   .HasMaxLength(1000);


            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);


        }
    }
}
