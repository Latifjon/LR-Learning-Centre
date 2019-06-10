using System;
using System.Collections.Generic;

namespace LearningCentre.Database
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
