using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models;
/// <summary>
/// Метч
/// </summary>
public class Match : BaseEntity
{
    /// <summary>
    /// Индификатор пользователя, который отправил метч
    /// </summary>
    public int UserSenderId { get; set; }

    /// <summary>
    /// Пользователь который отправил метч
    /// </summary>
    public User UserSender { get; set; }

    /// <summary>
    /// Индификатор пользователя, который получил метч
    /// </summary>
    public int UserRecieverId { get; set; }

    /// <summary>
    /// Пользователь, который получил метч
    /// </summary>
    public User UserReciever { get; set; }

    /// <summary>
    /// Cогласен ли второй пользователь на метч
    /// </summary>
    public bool IsAnswerPositive {  get; set; }
}
