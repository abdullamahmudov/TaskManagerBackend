using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerBase.Models;

public class User
{
    public Guid Id { get; set; }
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Login { get; set; }
    public string? Name { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? AuthKey { get; set; }
}
