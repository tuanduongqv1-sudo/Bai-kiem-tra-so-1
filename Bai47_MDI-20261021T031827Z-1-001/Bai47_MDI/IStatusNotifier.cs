namespace Bai47_MDI
{
    /// <summary>
    /// Interface giao tiếp giữa MDI Parent và MDI Child.
    /// Form con implement interface này để truyền thông điệp lên StatusStrip của Form cha.
    /// </summary>
    public interface IStatusNotifier
    {
        /// <summary>
        /// Callback được gán bởi FormMain, cho phép Form con gửi thông báo lên StatusStrip.
        /// </summary>
        Action<string>? OnStatusChanged { get; set; }
    }
}
