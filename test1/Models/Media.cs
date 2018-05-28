using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace test1.Models
{
    class Media
    {
        WindowsMediaPlayer Player;
        public bool isStop = false;

        public Media(String URL, bool isRepeat, bool isPlay)
        {
            Player = new WindowsMediaPlayer();
            Player.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError += new _WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.uiMode = "invisible";
            Player.URL = URL;
            Player.settings.setMode("loop", isRepeat);
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                isStop = true;
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
        }

        public void Play()
        {
            Player.controls.play();
        }

        public void Pause()
        {
            Player.controls.pause();
        }

        public void Stop()
        {
            Player.controls.stop();
        }
    }
}
