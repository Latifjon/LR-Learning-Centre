using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    public partial class Subject
    {
        public Subject()
        {
            Teacher = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Teacher> Teacher { get; set; }
    }
}
