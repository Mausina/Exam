using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GymApp.Data;
using GymApp.Models;

namespace GymApp
{
    public partial class MainWindow : Window
    {
        ClubData db = new ClubData();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Q 1(i) Display Members
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMembers();
        }

        private void LoadMembers()
        {

            var query = db.Members.OrderBy(m => m.Surname).ToList();
            lbxMembers.ItemsSource = query;
        }

        // Q 1(j) Selection Changed
        private void lbxMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxMembers.SelectedItem is Member selectedMember)
            {

                txtId.Text = $"ID: {selectedMember.MemberId}";
                txtFirstName.Text = $"First Name: {selectedMember.FirstName}";
                txtLastName.Text = $"Last Name: {selectedMember.Surname}";
                txtContact.Text = $"Contact Number: {selectedMember.ContactNumber}";
                txtMembership.Text = $"Membership Type: {selectedMember.MembershipType}";
                txtDOB.Text = $"DOB: {selectedMember.DateOfBirth:dd/MM/yyyy}";

                LoadSessionsForMember(selectedMember.MemberId);
            }
        }

        public void LoadSessionsForMember(int memberId)
        {

            var sessions = db.TrainingSessions
                             .Where(ts => ts.MemberId == memberId)
                             .OrderBy(ts => ts.SessionDate)
                             .ToList();

            if (sessions.Count == 0)
            {
                lbxSessions.Visibility = Visibility.Collapsed;
                txtNoSessions.Visibility = Visibility.Visible;
            }
            else
            {
                lbxSessions.Visibility = Visibility.Visible;
                txtNoSessions.Visibility = Visibility.Collapsed;
                lbxSessions.ItemsSource = sessions;
            }
        }

        private void btnAddSession_Click(object sender, RoutedEventArgs e)
        {
            if (lbxMembers.SelectedItem is Member selectedMember)
            {
                AddSessionWindow addWin = new AddSessionWindow(selectedMember, db);
                addWin.Owner = this;
                addWin.ShowDialog();


                LoadSessionsForMember(selectedMember.MemberId);
            }
            else
            {
                MessageBox.Show("Please select a member first.");
            }
        }
    }
}
