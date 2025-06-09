using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerBase.Models;

public class User
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    /// <summary>
    /// Логин
    /// </summary>
    public string? Login { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    public string? Password { get; set; }
    /// <summary>
    /// Ключ авторизации
    /// </summary>
    public string? AuthKey { get; set; }
}
