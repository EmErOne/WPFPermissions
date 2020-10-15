using System.ComponentModel;

namespace PermissionsUI.Models
{
    public class PermissionGridItem : INotifyPropertyChanged
    {
        private readonly PermissionProperty _permissionProperty;

        public event PropertyChangedEventHandler PropertyChanged;

        #region IsAdminSet

        private bool isAdminSet;

        public bool IsAdminSet
        {
            get
            {
                return isAdminSet;
            }
            set
            {
                if (isAdminSet != value)
                {
                    isAdminSet = value;
                    if (value)
                    {
                        IsManagerSet = false;
                        IsUserSet = false;
                    }

                    _permissionProperty.AuthorizedGroup = UserGroups.Admin;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAdminSet)));
                }
            }
        }

        #endregion IsAdminSet

        #region IsManagerSet

        private bool isManagerSet;

        public bool IsManagerSet
        {
            get
            {
                return isManagerSet;
            }
            set
            {
                if (isManagerSet != value)
                {
                    isManagerSet = value;
                    if (value)
                    {
                        IsAdminSet = false;
                        IsUserSet = false;
                    }

                    _permissionProperty.AuthorizedGroup = UserGroups.Manager;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsManagerSet)));
                }
            }
        }

        #endregion IsManagerSet

        #region IsUserSet

        private bool isUserSet;

        public bool IsUserSet
        {
            get
            {
                return isUserSet;
            }
            set
            {
                if (isUserSet != value)
                {
                    isUserSet = value;
                    if (value)
                    {
                        IsAdminSet = false;
                        IsManagerSet = false;
                    }

                    _permissionProperty.AuthorizedGroup = UserGroups.User;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsUserSet)));
                }
            }
        }

        #endregion IsUserSet

        public string Title => _permissionProperty.Title;

        public string Description => _permissionProperty.Description;

        public PermissionGridItem(PermissionProperty permissionProperty)
        {
            _permissionProperty = permissionProperty;

            if (permissionProperty.AuthorizedGroup == UserGroups.Admin)
            {
                IsAdminSet = true;
            }
            else if (permissionProperty.AuthorizedGroup == UserGroups.Manager)
            {
                IsManagerSet = true;
            }
            else
            {
                IsUserSet = true;
            }
        }
    }
}