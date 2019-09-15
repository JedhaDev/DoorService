using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DoorService
{

    public interface IDoorServiceCallback
    {
        /// <summary>
        /// notify a new login into the system
        /// </summary>
        /// <param name="application"></param>
        [OperationContract(IsOneWay = true)]
        void NotifyLogin(string application);

        /// <summary>
        /// notify a door status change
        /// </summary>
        /// <param name="application"></param>
        /// <param name="door"></param>
        /// <param name="status"></param>
        [OperationContract(IsOneWay = true)]
        void NotifyDoorChanged(string application, int door, bool status);

        /// <summary>
        /// notify a logout from the system
        /// </summary>
        /// <param name="application"></param>
        [OperationContract(IsOneWay = true)]
        void NotifyLogout(string application);
    }
}
