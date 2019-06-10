using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    public partial class City
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
    }
}
