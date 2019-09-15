using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DoorService
{
    [ServiceContract(
    SessionMode = SessionMode.Required,
    CallbackContract = typeof(IDoorServiceCallback))]
    public interface IDoorService
    {
        /// <summary>
        /// Login into the system
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [OperationContract()]
        void Login(string application);

        /// <summary>
        /// set door status
        /// </summary>
        /// <param name="door"></param>
        /// <param name="status"></param>
        [OperationContract(IsOneWay = true)]
        void SetDoorStatus(int door, bool status);


        [OperationContract()]
        List<Door> GetDoorsStatus();

        /// <summary>
        /// logout from the system
        /// </summary>
        /// <param name="application"></param>
        [OperationContract(IsOneWay = true)]
        void Logout();
    }


}
