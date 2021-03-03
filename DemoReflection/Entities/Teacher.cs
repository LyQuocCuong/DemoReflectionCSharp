using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Entities
{
    public class Teacher
    {
        public string SpecialId;
        public string Id { get; set; }
        public string FullName { get; set; }
        public double[] Scores { get; set; }
        public bool IsBoy { get; set; }
        public Classroom FavoriteClassroom { get; set; }
        public List<Classroom> MandatoryClassrooms { get; set; }

        public Teacher(string specialId)
        {
            this.SpecialId = specialId;
        }
    }
}
