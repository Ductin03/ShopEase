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
        public UnitOfWork(ShopEaseDbContext context,
                          IRoleRepository roleRepository,
                          IUserRepository userRepository,
                          ICategoryRepository categoryRepository,
                          IProductRepository productRepository
            ) { 
            _context = context;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public IRoleRepository roleRepository => _roleRepository;

        public IUserRepository userRepository => _userRepository;

        public ICategoryRepository categoryRepository => _categoryRepository;

        public IProductRepository productRepository => _productRepository;

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
