using ClothingStore.Entities;
using ClothingStore.Models.RequestModels;
using ClothingStore.Repository;
using ClothingStore.UnitOfWork;
using ShopEase.Models.RequestModels;

namespace ClothingStore.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteRoleAsync(Guid roleId)
        {
            var roleExist = await _unitOfWork.roleRepository.GetByRoleId(roleId);
            if (roleExist == null)
            {
                throw new Exception("Không tồn tại Role");
            }
            roleExist.IsDeleted = true;
            _unitOfWork.roleRepository.DeleteRole(roleExist);
            await _unitOfWork.SaveChangeAsync();


        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _unitOfWork.roleRepository.GetAllRoles();
        }

        public async Task Role(CreateRoleRequestModel model)
        {
            var role = new Role();
            role.Id = Guid.NewGuid();
            role.RoleName = model.RoleName;
            role.Description=model.Description;
            role.CreatedOn = DateTime.UtcNow;
            role.CreatedBy = model.CreatedBy;
            role.IsDeleted = false;
            _unitOfWork.roleRepository.CreateRole(role);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateRoleAsync(UpdateRoleRequestModel model)
        {
            var roleExist = await _unitOfWork.roleRepository.GetByRoleId(model.RoleId);
            if (roleExist == null)
            {
                throw new Exception("Không tồn tại Role");
            }
            roleExist.RoleName = model.RoleName;
            roleExist.Description = model.Description;
            roleExist.UpdatedOn = DateTime.UtcNow;
            roleExist.UpdatedBy = model.UpdatedBy;
            _unitOfWork.roleRepository.UpdateRole(roleExist);
            await _unitOfWork.SaveChangeAsync();
            
        }
    }
}
