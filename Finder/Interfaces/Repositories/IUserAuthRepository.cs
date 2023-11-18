using Finder.Models;

namespace Finder.Interfaces.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями
/// </summary>
public interface IUserAuthRepository
{
    /// <summary>
    /// Генерация JWT-токена
    /// </summary>
    /// <param name="user">Пользователь</param>
    /// <returns></returns>
    string GenerateJwtToken(User user);

    /// <summary>
    /// Создание пользователя
    /// </summary>
    /// <param name="newUser">Dto нового пользователя</param>
    /// <param name="password">Пароль</param>
    /// <returns></returns>
    Task<bool> CreateUser(User newUser, string password);

    /// <summary>
    /// Аутентификация
    /// </summary>
    /// <param name="username">Логин (e-mail)</param>
    /// <param name="password">Пароль</param>
    /// <returns></returns>
    Task<User?> Authenticate(string username, string password);
}
