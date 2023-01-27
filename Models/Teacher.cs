using System;
using System.Collections.Generic;

namespace Labb3.Models
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public int EmployeeId { get; set; }
        public string Subject { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;
    }
}
