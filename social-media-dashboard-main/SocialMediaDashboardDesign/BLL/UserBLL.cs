using SocialMediaDashboardDesign.DataAccess;
using SocialMediaDashboardDesign.Services;
using System;
using System.Runtime.Caching;
using System.Threading.Tasks;
using BCrypt.Net;

/// <summary>
/// Lớp Business Logic Layer (BLL) để xử lý các quy tắc nghiệp vụ liên quan đến người dùng.
/// </summary>
public class UserBLL
{
    #region Fields

    private UserDAL userDAL;
    private EmailService emailService;

    /// <summary>
    /// Cache trong bộ nhớ để lưu trữ mã PIN đặt lại mật khẩu tạm thời.
    /// 'static' để đảm bảo chỉ có một instance cache cho toàn bộ ứng dụng.
    /// </summary>
    private static MemoryCache pinCache = new MemoryCache("PasswordResetPins");

    #endregion

    #region Constructor

    /// <summary>
    /// Khởi tạo một instance mới của lớp UserBLL.
    /// </summary>
    public UserBLL()
    {
        userDAL = new UserDAL();
        emailService = new EmailService();
    }

    #endregion

    #region Authentication Methods

    /// <summary>
    /// Xác thực thông tin đăng nhập của người dùng.
    /// </summary>
    /// <param name="username">Tên người dùng.</param>
    /// <param name="password">Mật khẩu (chưa được băm).</param>
    /// <returns>Trả về true nếu tên người dùng và mật khẩu hợp lệ; ngược lại, trả về false.</returns>
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
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }

    /// <summary>
    /// Kiểm tra xem một người dùng đã tồn tại trong hệ thống hay chưa.
    /// </summary>
    /// <param name="username">Tên người dùng cần kiểm tra.</param>
    /// <returns>Trả về true nếu người dùng tồn tại; ngược lại, trả về false.</returns>
    public bool IsUserExists(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return false;
        }
        return userDAL.IsUserExists(username);
    }

    #endregion

    #region User Registration

    /// <summary>
    /// Đăng ký người dùng mới với các thông tin được cung cấp.
    /// Bao gồm xác thực dữ liệu đầu vào, băm mật khẩu và gọi DAL để lưu trữ.
    /// </summary>
    /// <param name="username">Tên người dùng.</param>
    /// <param name="password">Mật khẩu.</param>
    /// <param name="email">Địa chỉ email.</param>
    /// <param name="phoneNumber">Số điện thoại.</param>
    /// <returns>Trả về true nếu đăng ký thành công; ngược lại, trả về false.</returns>
    public bool RegisterUser(string username, string password, string email, string phoneNumber)
    {
        // 1. Basic validation
        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(phoneNumber))
        {
            return false;
        }

        if (username.Length < 5) return false;
        foreach (char c in username)
        {
            if (!char.IsLetterOrDigit(c)) return false;
        }

        // 2. Password policy
        if (password.Length < 8) return false;
        bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
        foreach (char ch in password)
        {
            if (char.IsUpper(ch)) hasUpper = true;
            else if (char.IsLower(ch)) hasLower = true;
            else if (char.IsDigit(ch)) hasDigit = true;
            else hasSpecial = true;
        }
        if (!(hasUpper && hasLower && hasDigit && hasSpecial)) return false;

        // 3. Email format
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            if (addr.Address != email) return false;
        }
        catch
        {
            return false;
        }

        // 4. Phone format: all digits, start with 0, length 9-11
        foreach (char ch in phoneNumber)
        {
            if (!char.IsDigit(ch)) return false;
        }
        if (!phoneNumber.StartsWith("0") || phoneNumber.Length < 9 || phoneNumber.Length > 11) return false;

        // 5. Business rule: username must be unique
        if (IsUserExists(username)) return false;

        // 6. Hash password and call DAL
        try
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return userDAL.RegisterUser(username, hashedPassword, email, phoneNumber);
        }
        catch (Exception)
        {
            // Nếu muốn: ghi log ở đây
            return false;
        }
    }

    /// <summary>
    /// Đăng ký người dùng mới một cách bất đồng bộ và gửi email chào mừng.
    /// Việc gửi email thất bại sẽ không ảnh hưởng đến kết quả đăng ký.
    /// </summary>
    /// <param name="username">Tên người dùng.</param>
    /// <param name="password">Mật khẩu.</param>
    /// <param name="email">Địa chỉ email.</param>
    /// <param name="phoneNumber">Số điện thoại.</param>
    /// <returns>Trả về một Task<bool> cho biết việc đăng ký vào cơ sở dữ liệu có thành công hay không.</returns>
    public async Task<bool> RegisterUserAsync(string username, string password, string email, string phoneNumber)
    {
        bool created = RegisterUser(username, password, email, phoneNumber);
        if (!created) return false;

        // Gửi email chào mừng (không rollback DB nếu email thất bại)
        try
        {
            string subject = "Welcome to Our App";
            string body = $"<p>Hi {username},</p><p>Thank you for registering.</p>";
            await emailService.SendEmailAsync(email, subject, body);
        }
        catch
        {
            // Ghi log nếu muốn, nhưng không trả về false vì đăng ký đã thành công
        }

        return true;
    }

    #endregion

    #region Password Management

    /// <summary>
    /// Tạo và gửi mã PIN đặt lại mật khẩu đến email của người dùng một cách bất đồng bộ.
    /// </summary>
    /// <param name="username">Tên người dùng đang yêu cầu đặt lại mật khẩu.</param>
    /// <param name="providedEmail">Email do người dùng cung cấp để xác thực.</param>
    /// <returns>Trả về một Task<bool> cho biết email chứa mã PIN đã được gửi thành công hay chưa.</returns>
    public async Task<bool> GenerateAndSendPasswordResetPinAsync(string username, string providedEmail)
    {
        // 1. Lấy email chính xác của user từ DB
        string storedEmail = userDAL.GetEmailByUsername(username);

        // 2. Kiểm tra xem user có tồn tại và email có khớp không (không phân biệt hoa thường)
        if (storedEmail == null || !storedEmail.Equals(providedEmail, StringComparison.OrdinalIgnoreCase))
        {
            return false; // Email không khớp hoặc user không tồn tại
        }

        // Nếu email khớp, tiếp tục logic tạo và gửi PIN
        string pin = new Random().Next(100000, 999999).ToString("D6");

        var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10) };
        pinCache.Set(providedEmail, pin, cacheItemPolicy);

        string subject = "Your Password Reset PIN";
        string body = $"<p>Hi {username},</p><p>Your password reset PIN is: <b>{pin}</b></p><p>This PIN will expire in 10 minutes.</p>";

        bool sent = await emailService.SendEmailAsync(providedEmail, subject, body);

        return sent;
    }

    /// <summary>
    /// Xác minh mã PIN đặt lại mật khẩu do người dùng cung cấp.
    /// </summary>
    /// <param name="email">Email đã nhận mã PIN.</param>
    /// <param name="pin">Mã PIN cần xác minh.</param>
    /// <returns>Trả về true nếu mã PIN hợp lệ và còn hạn; ngược lại, trả về false.</returns>
    public bool VerifyPasswordResetPin(string email, string pin)
    {
        if (pinCache.Contains(email))
        {
            string storedPin = pinCache.Get(email) as string;
            if (storedPin == pin)
            {
                // Xóa PIN khỏi cache sau khi xác minh thành công để tránh sử dụng lại
                pinCache.Remove(email);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Đặt lại mật khẩu của người dùng sau khi đã xác minh mã PIN thành công.
    /// </summary>
    /// <param name="email">Email của người dùng.</param>
    /// <param name="pin">Mã PIN đã được xác minh.</param>
    /// <param name="newPassword">Mật khẩu mới.</param>
    /// <returns>Trả về true nếu mật khẩu được cập nhật thành công; ngược lại, trả về false.</returns>
    public bool ResetPassword(string email, string pin, string newPassword)
    {
        // 1. Xác thực mã PIN trước
        if (!this.VerifyPasswordResetPin(email, pin))
        {
            return false; // PIN không đúng hoặc đã hết hạn
        }

        // 2. Nếu PIN đúng, băm mật khẩu mới
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

        // 3. Gọi DAL để cập nhật mật khẩu mới vào cơ sở dữ liệu
        return userDAL.UpdatePassword(email, hashedPassword);
    }

    #endregion
}