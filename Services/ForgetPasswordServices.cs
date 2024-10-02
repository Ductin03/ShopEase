using ClothingStore.Entities;
using ClothingStore.UnitOfWork;
using MailKit.Net.Smtp; 
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using ShopEase.Entities;
using ShopEase.Models.RequestModels;

namespace ShopEase.Services
{
    public class ForgetPasswordServices : IForgetPasswordServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmailSettingModel _emailSettingModel;

        public ForgetPasswordServices(IUnitOfWork unitOfWork,IOptions<EmailSettingModel> options)
        {
            _emailSettingModel = options.Value;
            _unitOfWork = unitOfWork;
        }
        public async Task SendEmail(MailRequest request)
        {
            var checkEmail = await _unitOfWork.userRepository.GetByEmail(request.Email);
            if (checkEmail is null)
            {
                throw new Exception("Email không tồn tại ");
            }
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailSettingModel.Email);
            email.To.Add(MailboxAddress.Parse(request.Email));
            email.Subject = request.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = request.EmailBody;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_emailSettingModel.Host, _emailSettingModel.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettingModel.Email, _emailSettingModel.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }


        public string GeneraterandomNumber()
        {
            Random random = new Random();
            string randomm = random.Next(0, 1000000).ToString("D6");
            return randomm;
        }
        public async Task SendOtpMail(string UserMail)
        {
            var mailRequest = new MailRequest();
            mailRequest.Email = UserMail;
            mailRequest.Subject = "Forget Password : OTP";
            var OtpText = GeneraterandomNumber();
            mailRequest.EmailBody = GeneralEmailBody(mailRequest.Email, OtpText);
            await SendEmail(mailRequest);

            var verification = new Verification();
            verification.Id = Guid.NewGuid();
            verification.Email = UserMail;
            verification.Otp = OtpText;
            verification.ExpiredDate = DateTime.UtcNow.AddSeconds(90);

            await _unitOfWork.verificationRepository.AddVerification(verification);
            await _unitOfWork.SaveChangeAsync();

        }

        public string GeneralEmailBody(string Name, string OtpText)
        {
            string emailBody = string.Empty;
            emailBody = "<div style='width=100%; background-color:grey'>";
            emailBody += "<h1>Hi " + Name + ", Forget OTP</h1>";
            emailBody += "<h2>Please Enter Otp  and Complete Password Reset</h2>";
            emailBody += "<h2>OTP text: " + OtpText + "</h2>";
            emailBody += "</div>";

            return emailBody;
        }

        public async Task<User> ResetPassword(string email, string otp, string NewPassword)
        {
            var checkEmail = await _unitOfWork.userRepository.GetByEmail(email);
            if (checkEmail is null)
            {
                throw new Exception("Email Không tồn tại");
            }
            var checkOtp= await _unitOfWork.verificationRepository.CheckOtp(otp);
            if (checkOtp is null)
            {
                throw new Exception("Otp sai hoặc đã hết hạn");
            }
            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                throw new Exception("Nhập vào newpass");
            }
            checkEmail.Password = BCrypt.Net.BCrypt.HashPassword(NewPassword);
            await _unitOfWork.userRepository.UpdateUser(checkEmail);
            await _unitOfWork.SaveChangeAsync();
            return checkEmail;
        }
    }
}
