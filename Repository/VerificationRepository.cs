using ClothingStore.Entities;
using Microsoft.EntityFrameworkCore;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;

namespace ShopEase.Repository
{
    public class VerificationRepository : IVerificationRepository
    {
        private readonly ShopEaseDbContext _context;
        public VerificationRepository(ShopEaseDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddVerification(Verification verification)
        {
            _context.Verification.Add(verification);
            return await Task.FromResult(true);
        }

        public async Task<Verification> CheckOtp(string otp)
        {
            return await _context.Verification.FirstOrDefaultAsync(x => x.Otp == otp);
        }
    }
}

