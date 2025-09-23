using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SocialMediaDashboardDesign.Services // Tạo một thư mục Services nếu cần
{
    public class EmailService
    {
        private readonly string _host = ConfigurationManager.AppSettings["SmtpHost"];
        private readonly int _port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
        private readonly string _user = ConfigurationManager.AppSettings["SmtpUser"];
        private readonly string _pass = ConfigurationManager.AppSettings["SmtpPass"];
        private readonly string _displayName = ConfigurationManager.AppSettings["SmtpDisplayName"];

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress(_user, _displayName);
                var toAddress = new MailAddress(toEmail);

                var smtp = new SmtpClient
                {
                    Host = _host,
                    Port = _port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, _pass)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Cho phép gửi email dạng HTML
                })
                {
                    await smtp.SendMailAsync(message);
                }
                return true;
            }
            catch (Exception)
            {
                // Ghi lại lỗi (log error) ở đây nếu cần
                return false;
            }
        }
    }
}