using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models;
/// <summary>
/// Метч
/// </summary>
public class Match : BaseEntity
{
    /// <summary>
    /// Индификатор пользователя, который кинул метч
    /// </summary>
    public User UserSender { get; set; }

    /// <summary>
    /// Индификатор пользователя, который получил метч
    /// </summary>
    [ForeignKey("UserReceiverId")]
    public User UserReciever { get; set; }

    /// <summary>
    /// Cогласен ли второй пользователь на метч
    /// </summary>
    public bool IsAnswerPositive {  get; set; }
}
