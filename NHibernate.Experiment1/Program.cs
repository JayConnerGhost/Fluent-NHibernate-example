using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace NHibernate.Experiment1
{
    class Program
    {
        static void Main(string[] args)
        {
           
                //restart here ->https://www.tutorialspoint.com/nhibernate/nhibernate_fluent_hibernate.htm
                using (var session = NHibernateHelper.OpenSession())
                {
                    var frenchExam = new Exam() {ExamName = "french", Students= new List<Student>()};
                    
                        var school = new School()
                        {
                            Name="Teds High"
                           
                        };
                        session.Save(school);

                        var student = new Student
                        {
                            FirstName = "Allan",
                            LastName = "Bomer",
                            School = school,
                        };
                    student.Exams = new List<Exam> {frenchExam};
                    frenchExam.Students.Add(student);
                    session.Save(frenchExam);
                    session.Save(student);
                session.Flush();
                      
                       
                    

                }

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var students = session.Query<Student>()
                        .Where(x => x.FirstName == "Allan").ToList();


                    transaction.Commit();
                }

            }
            Console.ReadLine();

        }
    }
}
