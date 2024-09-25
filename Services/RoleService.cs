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

        public async Task<List<Roles>> GetAllRolesAsync()
        {
            return await _unitOfWork.roleRepository.GetAllRoles();
        }

        public async Task Role(CreateRoleRequestModel model)
        {
            var role = new Roles();
            role.Id = Guid.NewGuid();
            role.RoleName = model.RoleName;
            role.Description=model.Description;
            role.CreateDate = DateTime.UtcNow;
            role.CreateBy = model.CreateBy;
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
            roleExist.UpdateDate = DateTime.UtcNow;
            roleExist.UpdateBy = model.UpdateBy;
            _unitOfWork.roleRepository.UpdateRole(roleExist);
            await _unitOfWork.SaveChangeAsync();
            
        }
    }
}
