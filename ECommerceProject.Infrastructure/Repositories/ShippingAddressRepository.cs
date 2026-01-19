namespace ECommerceProject.Infrastructure.Repositories
{
    public class ShippingAddressRepository : Repository<ShippingAddress>, IShippingAddressRepository
    {
        public ShippingAddressRepository(ApplicationDbContext context) : base(context)
        {   
        }

    }
}
