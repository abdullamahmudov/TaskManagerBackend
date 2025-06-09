using TaskManagerBase.Enums;

namespace TaskManagerBase.Models.Shared;

public class ChangedTask
{
    /// <summary>
    /// Идентификатор изменяемой задачи
    /// </summary>
    public required string Id { get; set; }
    /// <summary>
    /// Статус
    /// </summary>
    public CRMTaskStatus? Status { get; set; }
    /// <summary>
    /// Фактическое время завершения задачи
    /// </summary>
    public ulong? TimeToComplite;
}
