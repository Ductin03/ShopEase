using ClothingStore.Repository;
using ShopEase.Repository;

namespace ClothingStore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository roleRepository { get; }
        IUserRepository userRepository { get; }
        ICategoryRepository categoryRepository { get; }
        IProductRepository productRepository { get; }
        IVerificationRepository verificationRepository { get; }
        ICartRepository cartRepository { get; }
        IOrderRepository orderRepository { get; }

        Task SaveChangeAsync();
        
    }
}
