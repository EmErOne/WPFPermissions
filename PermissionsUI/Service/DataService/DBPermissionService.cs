using PermissionsUI.Models;
using System.Collections.Generic;

namespace PermissionsUI.Service.DataService
{
    /// <summary>
    /// Diese Klasse dient zum Laden von PermissionProperties aus der Datenbank.
    /// </summary>
    public static class DBPermissionService
    {
        public static List<PermissionProperty> permissionProperties;

        /// <summary>
        /// Lädt alle PermissionProperties.
        /// </summary>
        /// <returns></returns>
        public static List<PermissionProperty> GetPermissionProperties()
        {
            if (permissionProperties == null)
            {
                permissionProperties = new List<PermissionProperty>
                {
                new PermissionProperty() { ElementName = "AdminBorder", AuthorizedGroup = UserGroups.Admin, Title = "Show admin area.", Description = "This means that the user can see the admin area."},
                new PermissionProperty() { ElementName = "ManagerBorder", AuthorizedGroup = UserGroups.Manager, Title = "Show manager area.", Description = "This means that the user can see the manager area." },
                new PermissionProperty() { ElementName = "UserBorder", AuthorizedGroup = UserGroups.User , Title = "Show user area.", Description = "This means that the user can see the user area."}
                };
            }

            return permissionProperties;
        }
    }
}