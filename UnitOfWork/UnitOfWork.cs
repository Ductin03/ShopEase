using ClothingStore.Entities;
using ClothingStore.Repository;
using ShopEase.Repository;

namespace ClothingStore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopEaseDbContext _context;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IVerificationRepository _verificationRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        public UnitOfWork(ShopEaseDbContext context,
                          IRoleRepository roleRepository,
                          IUserRepository userRepository,
                          ICategoryRepository categoryRepository,
                          IProductRepository productRepository,
                          IVerificationRepository verificationRepository,
                          ICartRepository cartRepository,
                          IOrderRepository orderRepository
            ) { 
            _context = context;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _verificationRepository = verificationRepository;
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }
        public IRoleRepository roleRepository => _roleRepository;

        public IUserRepository userRepository => _userRepository;

        public ICategoryRepository categoryRepository => _categoryRepository;

        public IProductRepository productRepository => _productRepository;

        public IVerificationRepository verificationRepository => _verificationRepository;

        public ICartRepository cartRepository => _cartRepository;

        public IOrderRepository orderRepository => _orderRepository;

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
