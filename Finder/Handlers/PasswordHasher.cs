using System.Security.Cryptography;

namespace Finder.Handlers;

/// <summary>
/// Класс для реализации хэширования паролей
/// </summary>
public class PasswordHasher
{
    /// <summary>
    /// Хэширование пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <returns></returns>
    public string HashPassword(string password)
    {
        using (var algorithm = new Rfc2898DeriveBytes(password, 16, 10000))
        {
            byte[] hash = algorithm.GetBytes(20);
            byte[] salt = algorithm.Salt;

            // Конкатенация соли и хэша для хранения в базе данных
            byte[] hashWithSaltBytes = new byte[salt.Length + hash.Length];
            Array.Copy(salt, 0, hashWithSaltBytes, 0, salt.Length);
            Array.Copy(hash, 0, hashWithSaltBytes, salt.Length, hash.Length);

            string savedPasswordHash = Convert.ToBase64String(hashWithSaltBytes);
            return savedPasswordHash;
        }
    }

    /// <summary>
    /// Верификация пароля
    /// </summary>
    /// <param name="enteredPassword">Введенный пароль</param>
    /// <param name="savedPasswordHash">Сохраненный хэш пароля</param>
    /// <returns></returns>
    public bool VerifyPassword(string enteredPassword, string savedPasswordHash)
    {
        byte[] hashWithSaltBytes = Convert.FromBase64String(savedPasswordHash);

        byte[] salt = new byte[16];
        Array.Copy(hashWithSaltBytes, 0, salt, 0, 16);

        using (var algorithm = new Rfc2898DeriveBytes(enteredPassword, salt, 10000))
        {
            byte[] enteredPasswordHash = algorithm.GetBytes(20);

            // Проверка совпадения хэша введенного пароля с хэшем в базе данных
            for (int i = 0; i < 20; i++)
            {
                if (hashWithSaltBytes[i + 16] != enteredPasswordHash[i])
                    return false;
            }
            return true;
        }
    }
}