namespace Bai48_AsyncProgressBar
{
    /// <summary>
    /// Interface giao tiếp giữa MDI Parent và MDI Child.
    /// </summary>
    public interface IStatusNotifier
    {
        Action<string>? OnStatusChanged { get; set; }
    }

    /// <summary>
    /// Interface mở rộng cho Bài 4.8 - cho phép Form con cập nhật ProgressBar trên Form cha.
    /// </summary>
    public interface IProgressNotifier : IStatusNotifier
    {
        Action<int>? OnProgressChanged { get; set; }
    }
}
