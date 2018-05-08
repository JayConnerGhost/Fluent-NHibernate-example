using FluentNHibernate.Mapping;

namespace NHibernate.Experiment1
{
    public class StudentMap:ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            References(x => x.School);
            HasManyToMany(x => x.Exams)
                .Cascade.All()
                .Inverse()
                .Table("StudentExam");
         
        }
    }

    public class ExamMap:ClassMap<Exam>
    {
        public ExamMap()
        {
            Id(x => x.Id);
            Map(x => x.ExamName);
            HasManyToMany(x => x.Students)
                .Cascade.All()
                .Table("StudentExam");
        }

    }

    public class SchoolMap : ClassMap<School>
    {
        public SchoolMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Table("School");
        }
    }
}