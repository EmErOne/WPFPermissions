using PermissionsUI.Models;
using PermissionsUI.Service.DataService;
using System.Collections.Generic;
using System.Windows;

namespace PermissionsUI.Service.Permissions
{
    /// <summary>
    /// Dieser Service dient zum Setzten der Visibility von UIElementen anhand des Users.
    /// </summary>
    public class PermissionService
    {
        /// <summary>
        /// User welcher einer bestimmten Gruppe angehört.
        /// </summary>
        private readonly UserContext user;

        /// <summary>
        /// Erstellt einen PermissionService.
        /// </summary>
        /// <param name="user"></param>
        public PermissionService(UserContext user)
        {
            this.user = user;
        }

        /// <summary>
        /// Setzt die Visibility Eigenschaft in einem View.
        /// </summary>
        /// <param name="view">UIElement</param>
        public void SetPermissions(FrameworkElement view)
        {
            var permissionList = DBPermissionService.GetPermissionProperties();

            foreach (FrameworkElement frameworkElement in FindLogicalChildren(view))
            {
                var permission = GetPermissionProperty(frameworkElement.Name, permissionList);
                if (permission != null)
                {
                    if (permission.AuthorizedGroup > user.Group)
                    {
                        frameworkElement.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        /// <summary>
        /// Sucht nach einer PermissionProperty, welche aus einer DB kommen kann.
        /// </summary>
        /// <param name="name">Name der PermissionProperty</param>
        /// <param name="permissionList">Gesamtliste aller PermissionProperties</param>
        /// <returns>PermissionProperty</returns>
        private PermissionProperty GetPermissionProperty(string name, List<PermissionProperty> permissionList)
        {
            if (!string.IsNullOrEmpty(name))
            {
                foreach (var permission in permissionList)
                {
                    if (permission.ElementName == name)
                    {
                        return permission;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Sucht Recursiv nach allen UIElementen in einem FrameworkElement.
        /// </summary>
        /// <param name="depObj">Parent UIElementen</param>
        /// <returns></returns>
        private IEnumerable<FrameworkElement> FindLogicalChildren(DependencyObject depObj)
        {
            if (depObj != null)
            {
                foreach (object rawChild in LogicalTreeHelper.GetChildren(depObj))
                {
                    if (rawChild is DependencyObject child)
                    {
                        if (child is FrameworkElement element)
                        {
                            yield return element;
                        }

                        foreach (FrameworkElement childOfChild in FindLogicalChildren(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }
    }
}