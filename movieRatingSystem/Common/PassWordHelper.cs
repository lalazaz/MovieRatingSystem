namespace movieRatingSystem.Common;

public class PassWordHelper
{
    public static string GetPasswordHash(string password)
    {
        // 在实际应用中，你应该使用适当的密码哈希算法来计算哈希值
        // 以下是一个简单的示例，实际应该使用更安全的哈希算法，例如BCrypt、Argon2等
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // 将哈希值转换为字符串
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}