namespace Finder.Models;

/// <summary>
/// Пользователь
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль от аккаунта
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Фото пользователя
    /// </summary>
    public byte[]? Photo { get; set; }

    /// <summary>
    /// Список интересов
    /// </summary>
    public List<Interest>? Interests { get; set; }

    /// <summary>
    /// Сообщения
    /// </summary>
    public List<Message>? Messages { get; set; }

}
