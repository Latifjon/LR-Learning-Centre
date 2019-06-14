using System;
using System.Collections.Generic;
using LearningCentre.Logics.Helpers;
using Newtonsoft.Json;

namespace LearningCentre.Database
{
    /// <summary>
    /// 
    /// </summary>
    public  class Student
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NativeLanguage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Citizenship { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? PassportNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorkPlace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PlaceOfStudy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? DateOfRegistration { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int? UserProfileId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
