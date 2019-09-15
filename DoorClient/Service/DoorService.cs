using DoorClient.DoorServiceGateway;
using DoorClient.Model;
using DoorClient.ViewModel;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DoorClient.Service
{
    public class DoorService: IDoorServiceCallback
    {
        const string OPEN = "Open";
        const string CLOSE = "Close";

        private DoorServiceClient client = null;
        DoorViewModel model;

        /// <summary>
        /// 
        /// </summary>
        public DoorService(DoorViewModel doorViewModel)
        {
            this.model = doorViewModel;
        }

        #region public methods

        /// <summary>
        /// 
        /// </summary>
        public void Connect() => InitAsync();

        /// <summary>
        /// 
        /// </summary>
        public void Disconnect()
        {
            if (client != null)
            {
                client.Logout();
                client.Close();
            }
        }

        public void OpenCloseDoor(int id, bool status)
        {
            this.client.SetDoorStatusAsync(id, !status);
        }

        #endregion

        #region Service Implementations

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        async Task InitAsync()
        {
            try
            {
                this.client = new DoorServiceClient(new InstanceContext(this), "TcpBinding");
                this.client.Open();

                await this.client.LoginAsync(System.Environment.MachineName + GetExtraName());

            }
            catch (Exception ex)
            {
                model.AddLog(new LogData { AppName = "ERROR", Info = $"Communication error: {ex}" });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public async void GetDoors()
        {
            try
            {
                foreach (Door item in await client.GetDoorsStatusAsync())
                {
                    DoorData door = new DoorData(item.Id, item.Name, item.Status);
                    door.Image = LoadImage(door.Status ? "Open.png" : "Close.png");
                    model.AddDoor(door);
                }

            }
            catch (Exception ex)
            {
                model.AddLog(new LogData { AppName = "ERROR", Info = $"Communication error: {ex}" });
            }
        }

        #endregion

        #region Implementation IDoorServiceCallback

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public void NotifyDoorChanged(string application, int id, bool status)
        {
            DoorData data = new DoorData(id, "", status);

            DoorData door = model.GetDoor(data.Id);
            door.Status = !data.Status;
            door.Image = LoadImage(door.Status ? "Open.png" : "Close.png");

            model.AddLog(new LogData { AppName = application, Info = $"{door.Name} {(door.Status ? OPEN : CLOSE)}" });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        public void NotifyLogin(string application)
        {
            model.AddLog(new LogData { AppName = Convert.ToString(application), Info = "Login into the application" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        public void NotifyLogout(string application)
        {
            model.AddLog(new LogData { AppName = Convert.ToString(application), Info = "Logout from the application" });
        }

        #endregion

        #region helper

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private BitmapImage LoadImage(string filename)
        {
            return new BitmapImage(new Uri("pack://application:,,,/Images/" + filename));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetExtraName()
        {
            return "_" + DateTime.Now.ToString("HH_mm_ss");
        }
        #endregion
    }
}
