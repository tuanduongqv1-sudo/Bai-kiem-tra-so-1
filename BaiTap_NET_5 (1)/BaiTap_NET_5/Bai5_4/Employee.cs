using System;

namespace Bai5_4
{
    public class Employee
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public string Department { get; set; }   // Phòng ban
        public string Group { get; set; }        // Nhóm

        public Employee(string id, string name, string position, DateTime start, string dept, string group)
        {
            Id = id; FullName = name; Position = position;
            StartDate = start; Department = dept; Group = group;
        }
    }

    /// <summary>Thông tin gắn vào Node.Tag để lọc nhân viên.</summary>
    public class NodeInfo
    {
        public int Level { get; set; }           // 0 = Công ty, 1 = Phòng ban, 2 = Nhóm
        public string Department { get; set; }
        public string Group { get; set; }
    }
}
