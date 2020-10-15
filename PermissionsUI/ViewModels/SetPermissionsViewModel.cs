using PermissionsUI.Models;
using PermissionsUI.Service.DataService;
using System.Collections.ObjectModel;

namespace PermissionsUI.ViewModels
{
    public class SetPermissionsViewModel
    {
        public ObservableCollection<PermissionGridItem> PermissionPropertiesList { get; } = new ObservableCollection<PermissionGridItem>();

        public SetPermissionsViewModel()
        {
            var propList = DBPermissionService.GetPermissionProperties();
            foreach (var prop in propList)
            {
                PermissionPropertiesList.Add(new PermissionGridItem(prop));
            }
        }
    }
}