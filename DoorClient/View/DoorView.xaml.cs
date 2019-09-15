using DoorClient.Service;
using DoorClient.ViewModel;
using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace DoorClient.View
{
    /// <summary>
    /// Interaction logic for DoorView.xaml
    /// </summary>
    public partial class DoorView : UserControl
    {
        DoorViewModel model;

        /// <summary>
        /// 
        /// </summary>
        public DoorView()
        {
          
            model = new DoorViewModel();
            model.PropertyChanged += Model_PropertyChanged;
            DataContext = model;

            InitializeComponent();

            ((INotifyCollectionChanged)lstLog.Items).CollectionChanged += DoorView_CollectionChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoorView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ScrollToEnd(lstLog);
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("Change: " + e.PropertyName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButConnect_Click(object sender, RoutedEventArgs e)
        {
            butConnect.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listView"></param>
        private void ScrollToEnd(System.Windows.Controls.ListView listView)
        {
            listView.ScrollIntoView(listView.Items[listView.Items.Count - 1]);
        }
    }
}
