using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    public partial class Level
    {
        public Level()
        {
            PlacementTest = new HashSet<PlacementTest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PlacementTest> PlacementTest { get; set; }
    }
}
