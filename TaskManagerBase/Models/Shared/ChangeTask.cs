using TaskManagerBase.Enums;

namespace TaskManagerBase;

public class ChangeTask
{
    public required string Id { get; set; }
    public CRMTaskStatus? Status { get; set; }
    public ulong? TimeToComplite;
}
