﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models;
/// <summary>
/// Приветственное сообщение
/// </summary>
public class Message : BaseEntity
{
    /// <summary>
    /// Идентификатор пользователя, который отправил приветсвенное сообщение
    /// </summary>
    public int UserSenderId { get; set; }

    /// <summary>
    /// Пользователь, который отправил приветсвенное сообщение
    /// </summary>
    public User UserSender { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который получил приветсвенное сообщение
    /// </summary>
    public int UserReceiverId { get; set; }

    /// <summary>
    /// Пользователь, который получил приветсвенное сообщение
    /// </summary>
    public User UserReciever { get; set; }

    /// <summary>
    /// Текст приветственного сообщения
    /// </summary>
    public string Information { get; set; }
}
