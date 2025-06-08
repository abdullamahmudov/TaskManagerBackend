using TaskManagerBase.Enums;

namespace TaskManagerBase.Models.Shared;

public class ChangedTask
{
    public required string Id { get; set; }
    public CRMTaskStatus? Status { get; set; }
    public ulong? TimeToComplite;
}
