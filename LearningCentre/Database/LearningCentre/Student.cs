using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string NativeLanguage { get; set; }
        public string Citizenship { get; set; }
        public long? PassportNumber { get; set; }
        public int? CountryId { get; set; }
        public string WorkPlace { get; set; }
        public string PlaceOfStudy { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public int? UserProfileId { get; set; }

        public Country Country { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
