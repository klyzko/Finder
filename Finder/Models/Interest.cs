namespace Finder.Models;
/// <summary>
/// Интересы
/// </summary>
public class Interest : BaseEntity
{
    /// <summary>
    /// Название интереса
    /// </summary>
    public string InterestName { get; set; }

    /// <summary>
    /// Эмодзи на интерес
    /// </summary>
    public string? InterestEmoji { get; set; }

    /// <summary>
    /// Список пользователей
    /// </summary>
    public List<User>? Users { get; set; }
}
