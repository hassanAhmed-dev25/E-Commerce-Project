namespace ECommerceProject.Application.Interfaces
{
    public interface IUnitOfWork
    {

        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }

        ICartRepository Carts { get; }
        ICartItemRepository CartItems { get; }

        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IShippingAddressRepository ShippingAddresses { get; }


        Task SaveChangesAsync();

    }
}
