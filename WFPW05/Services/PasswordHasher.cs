using System.Text.RegularExpressions;

namespace WFPW05.Services
{
    public static class PasswordHasher
    {
        //проверка сложности пароля
        public static (bool IsValid, string ErrorMessage) ValidatePasswordStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return (false, "Пароль не может быть пустым.");

            //Проверка длины (8 и более символов)
            if (password.Length < 8)
                return (false, "Пароль должен содержать не менее 8 символов.");

            //Проверка на наличие заглавной буквы
            if (!Regex.IsMatch(password, @"[A-Z]"))
                return (false, "Пароль должен содержать хотя бы одну засловную букву.");

            //Проверка на наличие строчной буквы
            if (!Regex.IsMatch(password, @"[a-z]"))
                return (false, "Пароль должен содержать хотя бы одну строчную букву.");

            //Проверка на наличие цифры или спецсимвола
            if (!Regex.IsMatch(password, @"[0-9]"))
                return (false, "Пароль должен содержать хотя бы одну цифру.");

            return (true, string.Empty);
        }

        //Хеширует пароль (используется при регистрации)
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        //Проверяет введенный пароль на соответствие хешу (используется при логине)
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
