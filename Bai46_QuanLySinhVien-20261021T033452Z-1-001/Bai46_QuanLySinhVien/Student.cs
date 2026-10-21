using System.ComponentModel;

namespace Bai46_QuanLySinhVien
{
    /// <summary>
    /// Đối tượng Student với các thuộc tính hỗ trợ Data Binding hai chiều.
    /// Implement INotifyPropertyChanged để BindingSource tự động cập nhật UI.
    /// </summary>
    public class Student : INotifyPropertyChanged
    {
        private string _studentId = string.Empty;
        private string _fullName = string.Empty;
        private int _age;
        private string _gender = "Nam";
        private string _avatarPath = string.Empty;

        public string StudentId
        {
            get => _studentId;
            set { _studentId = value; OnPropertyChanged(nameof(StudentId)); }
        }

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }

        public int Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(nameof(Age)); }
        }

        public string Gender
        {
            get => _gender;
            set { _gender = value; OnPropertyChanged(nameof(Gender)); }
        }

        public string AvatarPath
        {
            get => _avatarPath;
            set { _avatarPath = value; OnPropertyChanged(nameof(AvatarPath)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
