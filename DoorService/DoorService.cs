using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Repository.Context;
using Repository.Entities;
using Repository.Repository;

namespace DoorService
{
    [ServiceBehavior(
       ConcurrencyMode = ConcurrencyMode.Single,
       InstanceContextMode = InstanceContextMode.PerSession)]
    public class DoorService : IDoorService, IDisposable
    {
        IDoorRepository doorRepository;
        private static List<IDoorServiceCallback> callbackList = new List<IDoorServiceCallback>();
        string application = null;

        /// <summary>
        /// 
        /// </summary>
        public DoorService() : base()
        {
            RepositoryContext context = new RepositoryContext();
            this.doorRepository = new DoorRepository(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public void Login(string application)
        {
            IDoorServiceCallback client = OperationContext.Current.GetCallbackChannel<IDoorServiceCallback>();

            if (!callbackList.Contains(client))
            {
                callbackList.Add(client);
            }

            this.application = application;

            callbackList.ForEach(
                delegate (IDoorServiceCallback callback)
                { callback.NotifyLogin(application); });
        }

        /// <summary>
        /// 
        /// </summary>
        public void Logout()
        {
            IDoorServiceCallback client = OperationContext.Current.GetCallbackChannel<IDoorServiceCallback>();

            if (callbackList.Contains(client))
            {
                callbackList.Remove(client);
            }

            callbackList.ForEach(
                delegate (IDoorServiceCallback callback)
                { callback.NotifyLogout(this.application); });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="door"></param>
        /// <param name="status"></param>
        public void SetDoorStatus(int door, bool status)
        {
            this.doorRepository.UpdateById(door, status);

            callbackList.ForEach(
                delegate (IDoorServiceCallback callback)
                {
                    Door item = this.doorRepository.GetById(door);
                    callback.NotifyDoorChanged(this.application, item.Id, item.Status);
                });
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Door> GetDoorsStatus()
        {
            return this.doorRepository.FindAll().ToList<Door>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (this.doorRepository != null) this.doorRepository = null;
        }
    }
}
