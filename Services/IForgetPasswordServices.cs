﻿using ClothingStore.Entities;
using ShopEase.Models.RequestModels;

namespace ShopEase.Services
{
    public interface IForgetPasswordServices
    {
        Task SendEmail(MailRequest request);
        string GeneraterandomNumber();
        Task SendOtpMail(string UserMail);
        Task<User> ResetPassword(string email, string otp, string NewPassword);
    }
}
