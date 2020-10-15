namespace PermissionsUI.Models
{
    /// <summary>
    /// Gruppe in welcher ein Nutzer sein kann.
    /// </summary>
    [System.Flags]
    public enum UserGroups : byte
    {
        User = 8,
        Manager = 64,
        Admin = 128
    }
}