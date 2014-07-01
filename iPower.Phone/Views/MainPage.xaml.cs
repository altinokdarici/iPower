using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace iPower.Phone.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxChannels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.MainViewModel MainModel = (ViewModel.MainViewModel)this.DataContext;
            if (MainModel != null)
                if (ListBoxChannels.SelectedItem != null)
                {
                    MainModel.SelectedChannel = (Models.Channel)ListBoxChannels.SelectedItem;
                    ListBoxChannels.SelectedItem = null;
                }

        }

    }
}