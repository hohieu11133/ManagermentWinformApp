using SocialMediaDashboardDesign.DataAccess;
using SocialMediaDashboardDesign.Services;
using System;
using System.Runtime.Caching;
using System.Threading.Tasks;
using BCrypt.Net;
// Trong file UserBLL.cs
public class UserBLL
{
    private UserDAL userDAL;
    private EmailService emailService;

    // ✅ BƯỚC 1: Tạo một đối tượng cache tĩnh để lưu trữ PIN
    // "static" để nó tồn tại trong suốt vòng đời của ứng dụng
    private static MemoryCache pinCache = new MemoryCache("PasswordResetPins");

    public UserBLL()
    {
        userDAL = new UserDAL();
        emailService = new EmailService();
    }

    public bool VerifyPasswordResetPin(string email, string pin)
    {
        // 1. Kiểm tra xem email có trong cache không (tức là đã yêu cầu PIN chưa và PIN còn hạn không)
        if (pinCache.Contains(email))
        {
            // 2. Lấy PIN đã lưu trong cache
            string storedPin = pinCache.Get(email) as string;

            // 3. So sánh với PIN người dùng nhập
            if (storedPin == pin)
            {
                // 4. Nếu đúng, xóa PIN khỏi cache để không thể sử dụng lại
                pinCache.Remove(email);
                return true;
            }
        }

        return false;
    }
    public bool IsUserExists(string username)
    {
        // Có thể thêm các quy tắc nghiệp vụ ở đây
        // Ví dụ: kiểm tra độ dài, ký tự đặc biệt...
        if (string.IsNullOrWhiteSpace(username))
        {
            return false;
        }

        // Gọi xuống DAL để kiểm tra trong CSDL
        return userDAL.IsUserExists(username);
    }
    public bool ValidateLogin(string username, string password)
    {
        // 1. Lấy mật khẩu đã băm từ CSDL thông qua DAL
        string storedHash = userDAL.GetPasswordHash(username);

        // 2. Nếu không tìm thấy user (hash là null), đăng nhập thất bại
        if (storedHash == null)
        {
            return false;
        }

        // 3. Dùng BCrypt để so sánh mật khẩu người dùng nhập với chuỗi đã băm
        // Hàm Verify sẽ tự xử lý salt và trả về true nếu khớp
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }
    public bool ResetPassword(string email, string pin, string newPassword)
    {
        // 1. Xác thực mã PIN trước
        if (!this.VerifyPasswordResetPin(email, pin))
        {
            // PIN không đúng hoặc đã hết hạn
            return false;
        }

        // 2. Nếu PIN đúng, băm mật khẩu mới bằng BCrypt
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

        // 3. Gọi DAL để cập nhật mật khẩu mới vào cơ sở dữ liệu
        return userDAL.UpdatePassword(email, hashedPassword);
    }

    public async Task<bool> GenerateAndSendPasswordResetPinAsync(string username, string providedEmail)
    {
        // 1. Lấy email chính xác của user từ DB
        string storedEmail = userDAL.GetEmailByUsername(username);

        // 2. Kiểm tra xem user có tồn tại và email có khớp không (không phân biệt hoa thường)
        if (storedEmail == null || !storedEmail.Equals(providedEmail, StringComparison.OrdinalIgnoreCase))
        {
            return false; // Email không khớp hoặc user không tồn tại
        }

        // Nếu email khớp, tiếp tục logic tạo và gửi PIN như cũ
        string pin = new Random().Next(100000, 999999).ToString("D6");

        // Lưu PIN vào Cache (giải pháp không sửa DB)
        var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10) };
        pinCache.Set(providedEmail, pin, cacheItemPolicy);

        // Gửi email
        string subject = "Your Password Reset PIN";
        string body = $"<p>Hi {username},</p><p>Your password reset PIN is: <b>{pin}</b></p><p>This PIN will expire in 10 minutes.</p>";

        bool sent = await emailService.SendEmailAsync(providedEmail, subject, body);

        return sent;
    }
}