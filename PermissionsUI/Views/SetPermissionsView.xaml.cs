using PermissionsUI.Models;
using PermissionsUI.ViewModels;
using System.Windows;

namespace PermissionsUI.Views
{
    /// <summary>
    /// Interaktionslogik für SetPermissionsView.xaml
    /// </summary>
    public partial class SetPermissionsView : Window
    {
        public SetPermissionsView()
        {
            InitializeComponent();
            this.DataContext = new SetPermissionsViewModel();
        }

        private void OpenMainWindowAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(new UserContext() { Group = UserGroups.Admin });
            mainWindow.Show();
        }

        private void OpenMainWindowAsManage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(new UserContext() { Group = UserGroups.Manager });
            mainWindow.Show();
        }

        private void OpenMainWindowAsUser_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(new UserContext() { Group = UserGroups.User });
            mainWindow.Show();
        }
    }
}