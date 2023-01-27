using System;
using System.Collections.Generic;

namespace Labb3.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int EmployeeId { get; set; }
        public string Fname { get; set; } = null!;
        public string? Lname { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
