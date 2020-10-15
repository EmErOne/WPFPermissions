namespace PermissionsUI.Models
{
    /// <summary>
    /// Infomation, welche in der Datenbank gehalten wird.
    /// </summary>
    public class PermissionProperty
    {
        /// <summary>
        /// Name des UIElements
        /// </summary>
        public string ElementName { get; set; }

        /// <summary>
        /// Welche Gruppe hat Zugriff.
        /// </summary>
        public UserGroups AuthorizedGroup { get; set; }

        /// <summary>
        /// Bezeichner der Property.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Beschreibung der Property.
        /// </summary>
        public string Description { get; set; }
    }
}