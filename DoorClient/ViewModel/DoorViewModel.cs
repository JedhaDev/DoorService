using DoorClient.Base;
using DoorClient.Model;
using DoorClient.Service;
using System;
using System.Collections.ObjectModel;

namespace DoorClient.ViewModel
{
    public class DoorViewModel : NotificationClass
    {


        DoorService service;

        public ObservableCollection<DoorData> DoorsData { get; private set; }

        public ObservableCollection<LogData> LogsData { get; private set; }

        public DoorViewModel()
        {
            DoorsData = new ObservableCollection<DoorData>();
            LogsData = new ObservableCollection<LogData>();
            service = new DoorService(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RelayCommand Connect
        {
            get
            {
                return new RelayCommand(param => ConnectService(), true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConnectService()
        {
            service.Connect();
            service.GetDoors();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RelayCommand Open
        {
            get
            {
                return new RelayCommand(param => OpenService(param), true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpenService(object id)
        {
            int doorId = Convert.ToInt32(id);
            bool status = GetDoor(doorId).Status;
            service.OpenCloseDoor(doorId, !status);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DoorData GetDoor(int id)
        {
            foreach (DoorData item in DoorsData)
            {
                if (item.Id == id) return item;
            }

            return new DoorData();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddDoor(DoorData item)
        {
            DoorsData.Add(item);
            OnPropertyChanged("DoorsData");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddLog(LogData item)
        {
            LogsData.Add(item);
            OnPropertyChanged("LogsData");
        }


    }
}
