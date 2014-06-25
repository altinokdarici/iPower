using GalaSoft.MvvmLight;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace iPower.Phone.ViewModel
{
    public class MainViewModel : ViewModel
    {
        #region Fields

        private Models.Channel _SelectedChannel;

        #endregion

        #region Properties

        public ObservableCollection<Models.Channel> Channels { get; set; }

        public Models.Channel SelectedChannel
        {
            get { return _SelectedChannel; }
            set
            {
                base.Set<Models.Channel>(ref this._SelectedChannel, value);
                StaticData.Selected.SelectedChannel = value;
                PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;
                frame.Navigate(new Uri("/Views/Channel.xaml", UriKind.Relative));
            }
        }

        #endregion

        public MainViewModel()
        {
            Channels = new ObservableCollection<Models.Channel>();
            Channels.Add(new Models.Channel() { Name = "Power FM", ChannelName = "powerFM", });
            Channels.Add(new Models.Channel() { Name = "Power Türk", ChannelName = "powerTurk" });
            Channels.Add(new Models.Channel() { Name = "Power Love FM", ChannelName = "powerLove" });
            Channels.Add(new Models.Channel() { Name = "Power XL", ChannelName = "powerXL" });
            Channels.Add(new Models.Channel() { Name = "Power Smooth Jazz", ChannelName = "powerJazz" });
            Channels.Add(new Models.Channel() { Name = "Power Rocks", ChannelName = "powerRocks" });
            Channels.Add(new Models.Channel() { Name = "Power Dance", ChannelName = "powerDance" });
            Channels.Add(new Models.Channel() { Name = "Power Minimix", ChannelName = "powerMinimix" });
            Channels.Add(new Models.Channel() { Name = "Power Salsa", ChannelName = "powerSalsa" });
            Channels.Add(new Models.Channel() { Name = "Power Akustik", ChannelName = "powerTurkAkustik" });
            Channels.Add(new Models.Channel() { Name = "PowerTürk Taptaze", ChannelName = "powerTurkTaptaze" });
            Channels.Add(new Models.Channel() { Name = "PowerTürk Aşk", ChannelName = "powerTurkAsk" });

        }

    }
}
