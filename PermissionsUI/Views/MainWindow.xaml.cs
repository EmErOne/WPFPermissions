using PermissionsUI.Models;
using PermissionsUI.Service.Permissions;
using System.Windows;

namespace PermissionsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UserContext user = new UserContext() { Group = UserGroups.User };
            PermissionService permissionService = new PermissionService(user);
            permissionService.SetPermissions(this);
        }

        public MainWindow(UserContext user)
        {
            InitializeComponent();

            PermissionService permissionService = new PermissionService(user);
            permissionService.SetPermissions(this);
        }
    }
}