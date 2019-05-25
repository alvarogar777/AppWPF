using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWPF.Model
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Lastname { get; set; }
        public  string Firstname { get; set; }
        public  DateTime HireDate { get; set; }
        public  DateTime  EnrollmentDate { get; set; }
        public virtual OfficeAssignment OfficeAsigment { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructor { get; set; }

    }
}
