using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace iPower.Phone.ViewModel
{

    public class ChannelViewModel : ViewModel
    {
        #region Fields

        DispatcherTimer SongTimer;
        private Models.Response _Response;
        private Repository.ChannelRepository ChannelRepository = new Repository.ChannelRepository();
        private bool IsFirstTime = true;
        PlayState _LastState = PlayState.Unknown;
        #endregion

        #region Properties

        public Models.Item SelectedSong
        {
            get { return StaticData.Selected.SelectedSong; }
            set
            {
                StaticData.Selected.SelectedSong = value;
                base.RaisePropertyChanged();
                if (StaticData.Selected.SelectedSong != null)
                    if (StaticData.Selected.SelectedSong.HasLyrics)
                    {
                        PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;
                        frame.Navigate(new Uri("/Views/Song.xaml", UriKind.Relative));
                    }
            }
        }

        public Models.Channel Channel
        {
            get
            {
                return StaticData.Selected.SelectedChannel;
            }
        }

        public TimeSpan RemainingTime
        {
            get
            {
                return TimeSpan.FromSeconds(NowPlaying.RemainingSeconds);
            }
        }

        public Models.Item NowPlaying
        {
            get
            {
                Models.Item Now = new Models.Item();
                if (_Response != null)
                    if (_Response.TimeLine.Count >= 0)
                        Now = this._Response.TimeLine[0];

                return Now;
            }
        }

        public Models.Response Response
        {
            get { return _Response; }
            set
            {
                base.Set<Models.Response>(ref this._Response, value);
                base.RaisePropertyChanged(() => NowPlaying);
            }
        }

        public PlayState LastState
        {
            get
            {
                return this._LastState;
            }
            set
            {
                base.Set<PlayState>(ref this._LastState, value);
                base.RaisePropertyChanged(() => ImageButtonSource);
            }
        }

        public string ImageButtonSource
        {
            get
            {
                return LastState != PlayState.Playing ? "/Assets/Play.png" : "/Assets/Stop.png";
            }
        }
        #endregion

        public ChannelViewModel()
        {
            SelectedSong = null;
            if (!base.IsInDesignMode)
            {

                Fill();
            }
        }

        void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            if (LastState != BackgroundAudioPlayer.Instance.PlayerState)
                LastState = BackgroundAudioPlayer.Instance.PlayerState;
        }

        public void Play()
        {
            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
                if (BackgroundAudioPlayer.Instance.CanPause) BackgroundAudioPlayer.Instance.Pause(); else BackgroundAudioPlayer.Instance.Stop();
            else
            {
                BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, StaticData.Selected.SelectedChannel.Name, null, null, null, StaticData.Selected.SelectedChannel.StreamUrl, EnabledPlayerControls.Pause);
            }


        }

        private async void Fill()
        {
            this.Response = await ChannelRepository.Get(this.Channel.ChannelName);
            if (this.Response != null)
            {
                this.SongTimer = new DispatcherTimer();
                this.SongTimer.Interval = TimeSpan.FromSeconds(1);
                this.SongTimer.Tick += SongTimer_Tick;
                this.SongTimer.Start();
                base.IsLoading = false;

                BackgroundAudioPlayer.Instance.Close();
                BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, StaticData.Selected.SelectedChannel.Name, null, null, null, StaticData.Selected.SelectedChannel.StreamUrl, EnabledPlayerControls.Pause);
                BackgroundAudioPlayer.Instance.PlayStateChanged += Instance_PlayStateChanged;
            }
            else
            {
                base.IsLoading = false;
                if (IsFirstTime)
                    ;//TODO: go back, main page
            }
            this.IsFirstTime = false;
        }

        private void SongTimer_Tick(object sender, object e)
        {

            this.NowPlaying.RemainingSeconds -= 1;
            if (this.NowPlaying.RemainingSeconds <= 0)
            {
                this.SongTimer.Stop();
                Fill();
            }
            else
            {
                base.RaisePropertyChanged(() => RemainingTime);
            }

        }
    }
}
