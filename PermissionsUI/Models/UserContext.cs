namespace PermissionsUI.Models
{
    /// <summary>
    /// Diese Klasse stellt einen Nutzer dar.
    /// </summary>
    public class UserContext
    {
        /// <summary>
        /// Gruppe in welcher sich der Nutzer befindet.
        /// </summary>
        public UserGroups Group { get; set; }
    }
}