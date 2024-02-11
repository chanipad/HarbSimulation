using ClassLibrary.HarborFramework.ShipInfo;
using System.Collections.Generic;

namespace ClassLibrary.HarborFramework.Utilities
{
    /// <summary>
    /// Manages access control for ships, allowing for granting and revoking access.
    /// </summary>
    public class AccessControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessControl"/> class.
        /// </summary>
        public AccessControl()
        {
            accessList = new List<Ship>();
        }

        /// <summary>
        /// Gets or sets the list of ships that have been granted access.
        /// </summary>
        private List<Ship> accessList { get; set; } = new List<Ship>();

        /// <summary>
        /// Grants access to the specified ship, adding it to the access list if it's not already present.
        /// </summary>
        /// <param name="ship">The ship to grant access to.</param>
        /// <remarks>
        /// If the ship is already in the access list, it will not be added again.
        /// </remarks>
        public void GrantAccess(Ship ship)
        {
            if (!accessList.Contains(ship))
            {
                accessList.Add(ship);
            }
        }

        /// <summary>
        /// Revokes access from the specified ship, removing it from the access list.
        /// </summary>
        /// <param name="ship">The ship to revoke access from.</param>
        /// <remarks>
        /// If the ship is not found in the access list, no action is taken.
        /// </remarks>
        public void RevokeAccess(Ship ship)
        {
            accessList.Remove(ship);
        }

        /// <summary>
        /// Checks if the specified ship has been granted access.
        /// </summary>
        /// <param name="ship">The ship to check access for.</param>
        /// <returns><c>true</c> if the ship has access; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// Access is determined by the presence of the ship in the access list.
        /// </remarks>
        public bool HasAccess(Ship ship)
        {
            return accessList.Contains(ship);
        }
    }
}
