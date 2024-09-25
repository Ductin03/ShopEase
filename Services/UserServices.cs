using ClothingStore.Entities;
using ClothingStore.Models.RequestModels;
using ClothingStore.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using ShopEase.Models.RequestModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClothingStore.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public UserServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<string> Authentication(LoginRequestModel model)
        {
            var user= await _unitOfWork.userRepository.GetByUserName(model.username);
            var role = await _unitOfWork.userRepository.GetRoleName(model.username);
            var isAuthen = BCrypt.Net.BCrypt.Verify(model.password,user.Password);
            if (!isAuthen) {
                throw new UnauthorizedAccessException("UnAuthorized");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email.ToString()),
                        new Claim("RoleName", role.ToString())   // Custom Role ID claim
                    }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public async Task CreateUser(CreateUserRequestModel model)
        {
            var username = await _unitOfWork.userRepository.GetByUserName(model.UserName);
            if(username != null)
            {
                throw new Exception("Username đã tồn tại! "); 
                
            }
            var roleExist = await _unitOfWork.roleRepository.GetByRoleId(model.RoleId);
            if (roleExist == null)
            {
                throw new Exception("Không tồn tại Role");
            }
            var user = new Users();
            user.Id = Guid.NewGuid();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.RoleId = model.RoleId;
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            user.Phone= model.Phone;
            user.BirthDay = model.BirthDay;
            user.Avatar= model.Avatar;
            user.CreateDate = DateTime.UtcNow;
            user.CreateBy = model.CreateBy;
            user.Address= model.Address;
            user.IsDeleted = false;
            await _unitOfWork.userRepository.CreateUser(user);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteUserAsync(Guid userid)
        {
            var userExist= await _unitOfWork.userRepository.GetByUserId(userid);
            if(userExist == null)
            {
                throw new Exception("User không tồn tại!");
            }
            userExist.IsDeleted = true;
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _unitOfWork.userRepository.GetAllUsers();
        }

        public async Task UpdateUser(UpdateUserRequestModel model)
        {
            var userExist = await _unitOfWork.userRepository.GetByUserId(model.UserId);
            if(userExist == null) {
                throw new Exception("Không tồn tại user");
                    }
            var roleExist = await _unitOfWork.roleRepository.GetByRoleId(model.RoleId);
            if(roleExist == null)
            {
                throw new Exception("Không tồn tại Role");
            }

            userExist.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            userExist.Email = model.Email;
            userExist.Address = model.Address;
            userExist.Phone = model.Phone;
            userExist.BirthDay = model.BirthDay;
            userExist.Avatar = model.Avatar;
            userExist.UpdateDate = DateTime.UtcNow;
            userExist.UpdateBy= model.UpdateBy;
            userExist.RoleId = model.RoleId;
            userExist.IsDeleted = false;
            _unitOfWork.userRepository.UpdateUser(userExist);
            await _unitOfWork.SaveChangeAsync();

        }
    }
}
