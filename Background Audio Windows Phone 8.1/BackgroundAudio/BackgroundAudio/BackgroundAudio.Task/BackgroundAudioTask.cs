namespace BackgroundAudio.Task
{
    using Windows.ApplicationModel.Background;
    using Windows.Media;
    using Windows.Foundation.Collections;
    using Windows.Media.Playback;
    using System;

    public sealed class BackgroundAudioTask : IBackgroundTask
    {
        private BackgroundTaskDeferral _deferral;
        private SystemMediaTransportControls _systemMediaTransportControl;
        private MediaPlayer _mediaPlayer;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // La clase SystemMediaTransportControls permite a tu aplicación usar los controles de 
            // transporte multimedia del sistema proporcionados por Windows y actualizar la información 
            // multimedia que se muestra.
            _systemMediaTransportControl = SystemMediaTransportControls.GetForCurrentView();
            _systemMediaTransportControl.IsEnabled = true;

            BackgroundMediaPlayer.MessageReceivedFromForeground += MessageReceivedFromForeground;
            BackgroundMediaPlayer.Current.CurrentStateChanged += BackgroundMediaPlayerCurrentStateChanged;

            taskInstance.Canceled += OnCanceled;
            taskInstance.Task.Completed += Taskcompleted;

            _deferral = taskInstance.GetDeferral();
        }

        /// <summary>
        /// Play
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        private void Play(string url, string title)
        {
            _mediaPlayer = BackgroundMediaPlayer.Current;
            _mediaPlayer.AutoPlay = true;
            _mediaPlayer.SetUriSource(new Uri(url));

            _systemMediaTransportControl.ButtonPressed += MediaTransportControlButtonPressed;
            _systemMediaTransportControl.IsPauseEnabled = true;
            _systemMediaTransportControl.IsPlayEnabled = true;
            _systemMediaTransportControl.DisplayUpdater.Type = MediaPlaybackType.Music;
            _systemMediaTransportControl.DisplayUpdater.MusicProperties.Title = title;
            _systemMediaTransportControl.DisplayUpdater.Update();
        }

        /// <summary>
        /// Pause
        /// </summary>
        private void Pause()
        {
            if (_mediaPlayer == null)
                _mediaPlayer = BackgroundMediaPlayer.Current;

            _mediaPlayer.Pause();
        }

        /// <summary>
        /// Mensajes recibidos desde UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageReceivedFromForeground(object sender, MediaPlayerDataReceivedEventArgs e)
        {
            ValueSet valueSet = e.Data;
            foreach (string key in valueSet.Keys)
            {
                switch (key)
                {
                    case "Play":
                        Play(valueSet[key].ToString(), valueSet["Title"].ToString());
                        break;
                    case "Pause":
                        Pause();
                        break;
                }
            }
        }

        /// <summary>
        ///     Cambios en el estado del MediaPlayer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BackgroundMediaPlayerCurrentStateChanged(MediaPlayer sender, object args)
        {
            switch (sender.CurrentState)
            {
                case MediaPlayerState.Playing:
                    _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Playing;
                    break;
                case MediaPlayerState.Paused:
                    _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Paused;
                    break;
                case MediaPlayerState.Stopped:
                    _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Stopped;
                    break;
                case MediaPlayerState.Closed:
                    _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Closed;
                    break;
            }
        }

        /// <summary>
        ///     Los controles de transporte del sistema generan el evento ButtonPressed cuando se presiona 
        ///     uno de los botones habilitados. La propiedad Button de SystemMediaTransportControlsButtonPressedEventArgs 
        ///     especifica qué botón se ha presionado. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MediaTransportControlButtonPressed(SystemMediaTransportControls sender,
            SystemMediaTransportControlsButtonPressedEventArgs args)
        {
            switch (args.Button)
            {
                case SystemMediaTransportControlsButton.Play:
                    BackgroundMediaPlayer.Current.Play();
                    break;
                case SystemMediaTransportControlsButton.Pause:
                    BackgroundMediaPlayer.Current.Pause();
                    break;
            }
        }

        private void Taskcompleted(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            BackgroundMediaPlayer.Shutdown();
            _deferral.Complete();
        }

        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            BackgroundMediaPlayer.Shutdown();
            _deferral.Complete();
        }
    }
}
