namespace ECommerceProject.Application.Interfaces
{
    public interface IUnitOfWork
    {

        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }


        Task SaveChangesAsync();

    }
}
