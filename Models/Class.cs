using System;
using System.Collections.Generic;

namespace Labb3.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string? ClassName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
