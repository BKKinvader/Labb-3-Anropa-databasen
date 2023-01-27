using System;
using System.Collections.Generic;

namespace Labb3.Models
{
    public partial class StudentGrade
    {
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public string? Grade { get; set; }
        public DateTime? GradeDate { get; set; }
        public int TeacherId { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Teacher Teacher { get; set; } = null!;
    }
}
