using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoorClient.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> handler;
        private bool isEnabled;

        public RelayCommand(Action<object> handler, bool isEnabled)
        {
            this.handler = handler;
            this.isEnabled = isEnabled;
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                if (value != isEnabled)
                {
                    isEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            handler(parameter);
        }
    }

}
