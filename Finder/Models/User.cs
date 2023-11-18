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
    public ICollection<Interest>? Interests { get; set; }

    /// <summary>
    /// Полученные сообщения
    /// </summary>
    public ICollection<Message>? SentMessages { get; set; }

    /// <summary>
    /// Отправленные сообщения
    /// </summary>
    public ICollection<Message>? ReceivedMessages { get; set; }

    /// <summary>
    /// Отправленные метчи
    /// </summary>
    public ICollection<Match>? SentMatches { get; set; }

    /// <summary>
    /// Полученные метчи
    /// </summary>
    public ICollection<Match>? ReceivedMatches { get; set; }

}
