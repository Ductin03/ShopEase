namespace ShopEase.Models.RequestModels
{
    public class ForgetPasswordRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }
    }
}
