namespace ECommerceProject.Application.Interfaces
{
    public interface IUnitOfWork
    {

        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        ICartRepository Carts { get; }
        ICartItemRepository CartItems { get; }


        Task SaveChangesAsync();

    }
}
