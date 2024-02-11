using ClassLibrary.HarborFramework.ShipInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Interfaces
{
    public interface IAccessControl
    {
        List<Ship> AccessList { get; set; }
        void GrantAccess(Ship ship);
        void RevokeAccess(Ship ship);
    }
}
