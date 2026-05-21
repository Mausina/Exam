using System.Data.Entity;
using GymApp.Models;
using System;
using System.Collections.Generic;

namespace GymApp.Data
{
    // Q 1(f) Extend DBContext
    public class ClubData : DbContext
    {
        public ClubData() : base("OODExam_YourFullName")
        {
            Database.SetInitializer(new ClubDataInitializer());
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
    }

    // Q 1(g) Database seed script
    public class ClubDataInitializer : DropCreateDatabaseIfModelChanges<ClubData>
    {
        protected override void Seed(ClubData context)
        {
            var member1 = new Member
            {
                FirstName = "Niamh",
                Surname = "Kelly",
                DateOfBirth = new DateTime(1998, 3, 14),
                ContactNumber = "087 333 4455",
                MembershipType = "Senior",
                TrainingSessions = new List<TrainingSession>
                {
                    new TrainingSession { SessionDate = new DateTime(2026, 3, 24, 18, 30, 0), SessionType = "Strength", DurationMinutes = 60, CoachNotes = "Good session - strong progress on squat depth. Monitor left knee." },
                    new TrainingSession { SessionDate = new DateTime(2026, 3, 26, 14, 0, 0), SessionType = "Cardio", DurationMinutes = 45, CoachNotes = "5km time trial followed by interval work. Best 5km time to date." }
                }
            };

            var member2 = new Member
            {
                FirstName = "Ciaran",
                Surname = "Murphy",
                DateOfBirth = new DateTime(1995, 8, 22),
                ContactNumber = "083 444 5566",
                MembershipType = "Junior",
                TrainingSessions = new List<TrainingSession>
                {
                    new TrainingSession { SessionDate = new DateTime(2026, 3, 25, 17, 0, 0), SessionType = "Skills", DurationMinutes = 75, CoachNotes = "First session back after injury. Took it easy – good attitude." },
                    new TrainingSession { SessionDate = new DateTime(2026, 3, 27, 17, 0, 0), SessionType = "Strength", DurationMinutes = 45, CoachNotes = "Light weights, focus on form. Progress from last session." }
                }
            };

            var member3 = new Member
            {
                FirstName = "Fiona",
                Surname = "Walsh",
                DateOfBirth = new DateTime(1975, 11, 5),
                ContactNumber = "089 555 6677",
                MembershipType = "Veteran",

                TrainingSessions = new List<TrainingSession>
                {
                    new TrainingSession { SessionDate = new DateTime(2026, 3, 23, 9, 0, 0), SessionType = "Recovery", DurationMinutes = 30, CoachNotes = "Stretching and mobility work. Essential after Sunday's match." },
                    new TrainingSession { SessionDate = new DateTime(2026, 3, 29, 10, 0, 0), SessionType = "Match", DurationMinutes = 90, CoachNotes = "Strong performance throughout. Led by example in the second half." }
                }
            };

            context.Members.Add(member1);
            context.Members.Add(member2);
            context.Members.Add(member3);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}