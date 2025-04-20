namespace PasswordManagerAPI.Helpers
{
    public static class EncryptionHelper
    {
        public static string EncryptPassword(string plainPassword)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainPassword);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string DecryptPassword(string encryptedPassword)
        {
            var base64EncodedBytes = Convert.FromBase64String(encryptedPassword);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
