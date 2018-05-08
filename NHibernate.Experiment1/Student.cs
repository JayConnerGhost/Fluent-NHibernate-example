using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Experiment1
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual School School { get; set; }
        public virtual IList<Exam> Exams { get; set; }
    }

    public class Exam
    {
        public virtual int Id { get; set; }
        public virtual string ExamName { get; set; }
        public virtual IList<Student> Students { get; set; }
    }

    public class School
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
     
    }
}
