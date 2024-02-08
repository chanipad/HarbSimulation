using ClassLibrary.HarborFramework.ShipInfo;

namespace ClassLibrary.HarborFramework.Utilities
{
    public class AccessControl
    {
        private List<Ship> accessList { get; set; }
    }

    /// <summary>
    /// Grants access to a ship by adding it to the access list.
    /// </summary>
    /// <param name="ship">The ship to grant access to.</param>
    /// <remarks>
    /// If the ship is already in the access list, this method will not add it again,
    /// preventing duplicates in the list.
    /// </remarks>

    public void GrantAccess(Ship ship)
        {
            if (!accessList.Contains(ship))
            {
                accessList.Add(ship);
            }
        }

    /// <summary>
    /// Revokes access from a ship by removing it from the access list.
    /// </summary>
    /// <param name="ship">The ship to revoke access from.</param>
    /// <remarks>
    /// If the ship is not found in the access list, this method will do nothing.
    /// </remarks>
    public void RevokeAccess(Ship ship)
    {
        accessList.Remove(ship);
    }

  
    /// <summary>
    /// Checks if a ship has been granted access (i.e., is present in the access list).
    /// </summary>
    /// <param name="ship">The ship to check access for.</param>
    /// <returns>true if the ship has access, otherwise false.</returns>
    /// <remarks>
    /// This method searches the access list for the specified ship and returns
    /// true if found, indicating the ship has been granted access.
    /// </remarks>
    public bool HasAccess(Ship ship)
    {
        return accessList.Contains(ship);
    }
}
