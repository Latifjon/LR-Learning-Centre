using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    public partial class PlacementTest
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? LevelId { get; set; }
        public DateTime? PlacementTestDate { get; set; }

        public Level Level { get; set; }
    }
}
