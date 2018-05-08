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
            Table("Student");
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