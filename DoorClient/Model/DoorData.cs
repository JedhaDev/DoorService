using DoorClient.Base;
using System.Windows.Media.Imaging;

namespace DoorClient.Model
{
    public class DoorData : NotificationClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DoorData()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Status"></param>
        public DoorData(int Id, string Name, bool Status)
        {
            this.Id = Id;
            this.Name = Name;
            this.Status = Status;
        }

        private BitmapImage image;
        public BitmapImage Image {
            get {
                return image;
            }
            set {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
    }
}
