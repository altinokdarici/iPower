﻿//-----------------------------------------------------------------------
// <copyright file="AudioPlayer.cs" company="Andrew Oakley">
//     Copyright (c) 2010 Andrew Oakley
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Lesser General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Lesser General Public License for more details.
//
//     You should have received a copy of the GNU Lesser General Public License
//     along with this program.  If not, see http://www.gnu.org/licenses.
// </copyright>
//-----------------------------------------------------------------------

namespace Shoutcast.Sample.Phone.Background.Playback
{
    using System;
    using System.Windows;
    using Microsoft.Phone.BackgroundAudio;

    /// <summary>
    /// Shoutcast audio player for background audio.
    /// </summary>
    public class AudioPlayer : AudioPlayerAgent
    {
        /// <summary>
        /// Static field that denotes if this class has been initialized.
        /// </summary>
        private static volatile bool classInitialized;

        /// <summary>
        /// Initializes a new instance of the AudioPlayer class.
        /// </summary>
        /// <remarks>
        /// AudioPlayer instances can share the same process. 
        /// Static fields can be used to share state between AudioPlayer instances
        /// or to communicate with the Audio Streaming agent.
        /// </remarks>
        public AudioPlayer()
        {
            if (!AudioPlayer.classInitialized)
            {
                AudioPlayer.classInitialized = true;

                // Subscribe to the managed exception handler
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Application.Current.UnhandledException += this.AudioPlayer_UnhandledException;
                });
            }
        }

        /// <summary>
        /// Called when the playstate changes, except for the Error state (see OnError)
        /// </summary>
        /// <param name="player">The BackgroundAudioPlayer</param>
        /// <param name="track">The track playing at the time the playstate changed</param>
        /// <param name="playState">The new playstate of the player</param>
        /// <remarks>
        /// <para>
        /// Play State changes cannot be cancelled. They are raised even if the application
        /// caused the state change itself, assuming the application has opted-in to the callback.
        /// </para>
        /// <para>
        /// Notable playstate events: 
        /// (a) TrackEnded: invoked when the player has no current track. The agent can set the next track.
        /// (b) TrackReady: an audio track has been set and it is now ready for playack.
        /// </para>
        /// <para>
        /// Call NotifyComplete() only once, after the agent request has been completed, including async callbacks.
        /// </para>
        /// </remarks>
        protected override void OnPlayStateChanged(BackgroundAudioPlayer player, AudioTrack track, PlayState playState)
        {
            System.Diagnostics.Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString() + ":  OnPlayStateChanged() - {0}", playState);
            switch (playState)
            {
                case PlayState.TrackEnded:
                    break;
                case PlayState.TrackReady:
                    player.Play();
                    break;
                case PlayState.Shutdown:
                    // TODO: Handle the shutdown state here (e.g. save state)
                    break;
                case PlayState.Unknown:
                    break;
                case PlayState.Stopped:
                    break;
                case PlayState.Paused:
                    break;
                case PlayState.Playing:
                    break;
                case PlayState.BufferingStarted:
                    break;
                case PlayState.BufferingStopped:
                    break;
                case PlayState.Rewinding:
                    break;
                case PlayState.FastForwarding:
                    break;
            }

            NotifyComplete();
        }

        /// <summary>
        /// Called when the user requests an action using application/system provided UI
        /// </summary>
        /// <param name="player">The BackgroundAudioPlayer</param>
        /// <param name="track">The track playing at the time of the user action</param>
        /// <param name="action">The action the user has requested</param>
        /// <param name="param">The data associated with the requested action.
        /// In the current version this parameter is only for use with the Seek action,
        /// to indicate the requested position of an audio track</param>
        /// <remarks>
        /// User actions do not automatically make any changes in system state; the agent is responsible
        /// for carrying out the user actions if they are supported.
        /// Call NotifyComplete() only once, after the agent request has been completed, including async callbacks.
        /// </remarks>
        protected override void OnUserAction(BackgroundAudioPlayer player, AudioTrack track, UserAction action, object param)
        {
            System.Diagnostics.Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString() + ":  OnUserAction() - {0}", action);
            switch (action)
            {
                case UserAction.Play:
                    // Since we are just restarting the same stream, this should be fine.
                    player.Track = track;
                    break;
                case UserAction.Stop:
                case UserAction.Pause:
                    player.Stop();

                    // Stop the background streaming agent.
                    Shoutcast.Sample.Phone.Background.Playback.AudioTrackStreamer.ShutdownMediaStreamSource();
                    break;
                case UserAction.FastForward:
                    break;
                case UserAction.Rewind:
                    break;
                case UserAction.Seek:
                    break;
                case UserAction.SkipNext:
                    break;
                case UserAction.SkipPrevious:
                    break;
            }

            NotifyComplete();
        }

        /// <summary>
        /// Called whenever there is an error with playback, such as an AudioTrack not downloading correctly
        /// </summary>
        /// <param name="player">The BackgroundAudioPlayer</param>
        /// <param name="track">The track that had the error</param>
        /// <param name="error">The error that occured</param>
        /// <param name="isFatal">If true, playback cannot continue and playback of the track will stop</param>
        /// <remarks>
        /// This method is not guaranteed to be called in all cases. For example, if the background agent 
        /// itself has an unhandled exception, it won't get called back to handle its own errors.
        /// </remarks>
        protected override void OnError(BackgroundAudioPlayer player, AudioTrack track, Exception error, bool isFatal)
        {
            if (isFatal)
            {
                Abort();
            }
            else
            {
                player.Track = null;
                NotifyComplete();
            }
        }

        /// <summary>
        /// Called by the operating system to alert a background agent that it is going to be put into a dormant state or terminated.
        /// </summary>
        protected override void OnCancel()
        {
            base.OnCancel();
            this.NotifyComplete();
        }

        /// <summary>
        /// Code to execute unhandled exceptions.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">ApplicationUnhandledExceptionEventArgs associated with this event.</param>
        private void AudioPlayer_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }
    }
}
