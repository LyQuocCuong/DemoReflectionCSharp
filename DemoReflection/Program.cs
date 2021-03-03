using DemoReflection.Entities;
using DemoReflection.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("208020")
            {
                Id = "111",
                FullName = "Henry John",
                Scores = new double[] { 5.6, 7.3, 8.9, 6.6 },
                IsBoy = true,
                FavoriteSubject = new Subject()
                {
                    Id = "1",
                    Name = "Math",
                },
                MandatorySubjects = new List<Subject>()
                {
                    new Subject()
                    {
                        Id = "2",
                        Name = "E.P"
                    },
                    new Subject()
                    {
                        Id = "3",
                        Name = "Chemistry",
                    },
                }
            };
            Teacher teacher = new Teacher("208020")
            {
                Id = "222",
                FullName = "Maradona John",
                Scores = new double[] { 5.6, 7.3, 8.9, 6.6 },
                IsBoy = false,
                FavoriteClassroom = new Classroom()
                {
                    Id = "10A4",
                    Name = "Nguyen Van A",
                },
                MandatoryClassrooms = new List<Classroom>()
                {
                    new Classroom()
                    {
                        Id = "11A1",
                        Name = "Nguyen Van B"
                    },
                    new Classroom()
                    {
                        Id = "12C5",
                        Name = "Nguyen Van C",
                    },
                }
            };
            ObjectReflection.Reflect(student);
            //ObjectReflection.Reflect(teacher);
            Console.ReadLine();
        }

    }
}
