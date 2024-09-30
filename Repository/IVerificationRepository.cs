using ClothingStore.Entities;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;

namespace ShopEase.Repository
{
    public interface IVerificationRepository
    {
        public Task<bool> AddVerification(Verification verification);
        public Task<Verification> CheckOtp(string otp);
    }
}
