using ClothingStore.Entities;

namespace ClothingStore.Repository
{
    public interface IUserRepository
    {
        Task CreateUser(Users users);
        Task<Users> GetByUserName(string username);
        Task<Users> GetByUserId(Guid userId);
        Task<string> GetRoleName(string username);
        Task UpdateUser(Users users);
        Task<List<Users>> GetAllUsers();
        Task DeleteUser(Users users);

    }

}
