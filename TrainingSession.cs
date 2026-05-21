using System;
using System.Collections.Generic;

namespace GymApp.Models
{
    // Q 1(c) Member class
    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string MembershipType { get; set; }

        // Q 1(e) One to Many relationship 
        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }

        public string DisplayName => $"{Surname}, {FirstName} - {ContactNumber}";
    }

    // Q 1(d) Training Session class
    public class TrainingSession
    {
        public int SessionId { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionType { get; set; }
        public int DurationMinutes { get; set; }
        public string CoachNotes { get; set; }

        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        public string DisplayNotes => CoachNotes?.Length > 50 ? CoachNotes.Substring(0, 50) + "..." : CoachNotes;
    }
}
