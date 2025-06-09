namespace TaskManagerBase.Enums
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    [Flags]
    public enum CRMTaskStatus
    {
        /// <summary>
        /// Задача создана
        /// </summary>
        Created = 1 << 0,
        /// <summary>
        /// Задача в процессе
        /// </summary>
        Processed = 1 << 1,
        /// <summary>
        /// Задача завершена
        /// </summary>
        complitted = 1 << 2,
    }
}