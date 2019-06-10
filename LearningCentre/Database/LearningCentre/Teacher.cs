using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
