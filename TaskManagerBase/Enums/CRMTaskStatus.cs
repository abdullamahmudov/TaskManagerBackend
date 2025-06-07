namespace TaskManagerBase.Enums
{
    [Flags]
    public enum CRMTaskStatus
    {
        Created = 1 << 0,
        Processed = 1 << 1,
        complitted = 1 << 2,
    }
}