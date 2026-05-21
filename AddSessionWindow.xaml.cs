using System;
using System.Windows;
using GymApp.Data;
using GymApp.Models;

namespace GymApp
{
    public partial class AddSessionWindow : Window
    {
        private Member _member;
        private ClubData _db;

        public AddSessionWindow(Member member, ClubData db)
        {
            InitializeComponent();
            _member = member;
            _db = db;
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dpDate.SelectedDate.HasValue && tpTime.SelectedTime.HasValue)
            {

                DateTime sessionDateTime = dpDate.SelectedDate.Value.Date + tpTime.SelectedTime.Value.TimeOfDay;

                var newSession = new TrainingSession
                {
                    SessionDate = sessionDateTime,
                    SessionType = cbxSessionType.Text,
                    DurationMinutes = int.TryParse(txtDuration.Text, out int dur) ? dur : 60,
                    CoachNotes = txtNotes.Text,
                    MemberId = _member.MemberId
                };

                _db.TrainingSessions.Add(newSession);
                _db.SaveChanges(); // [cite: 275]

                this.Close(); //  [cite: 275]
            }
            else
            {
                MessageBox.Show("Please select a valid date and time.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
