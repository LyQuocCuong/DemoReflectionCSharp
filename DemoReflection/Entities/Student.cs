using DemoReflection.CustomedAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Entities
{
    [Author(Name = "Henry", Country = "VN")]
    public class Student
    {
        public string SpecialId;
        [Required]
        public string Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [Range(12, 18)]
        public byte Age { get; set; }
        public double[] Scores { get; set; }
        public bool IsBoy { get; set; }
        public Subject FavoriteSubject { get; set; }
        public List<Subject> MandatorySubjects { get; set; }

        public Student()
        {

        }

        public Student(string specialId)
        {
            this.SpecialId = specialId;
        }

        public Student(string id, string FullName)
        {

        }

        public string Rank()
        {
            if (Scores.FirstOrDefault(s => s < 8) != 0)
            {
                return "B";
            }
            return "A";
        }

        public double Avg(int heso)
        {
            return this.Scores[0] * heso / 2;
        }

    }
}
