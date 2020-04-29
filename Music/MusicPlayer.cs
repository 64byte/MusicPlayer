using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Diagnostics;
using TagLib;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;
using WMPLib;

namespace MusicPlayer.Music
{
    // 재생 타입에 따른 enum 선언
    public enum PlayerRepeatType
    {
        OneTime, // 일회반복
        Continue, // 계속반복
        OneMusic // 한곡반복
    }

    public class MusicPlayer
    {
        // for singleton
        private static volatile MusicPlayer instance;
        private static object syncRoot = new object();

        // for instance
        // WMPLib의 Player를 생성한다.
        public WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private MusicList musicList = new MusicList();
        public int CurrentIndex { get; set; } = 1;
        public int CurrentPlayCount { get; set; }
        public double CurrentPosition { get; set; }
        public int LastPlayMusic { get; set; }
        public bool isShuffle;
        public PlayerRepeatType repeatType;

        public MusicPlayer()
        {
            Player.settings.autoStart = false;
            Player.PlayStateChange += Player_PlayStateChange;
        }

        // 싱글턴 인스턴트를 위한 생성
        public static MusicPlayer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new MusicPlayer();
                    }
                }

                return instance;
            }
        }

        // 음악리스트의 값에 대한 프로퍼티
        public MusicList MusicList
        {
            get { return musicList; }
            set
            {
                musicList = value;
            }
        }

        // Shuffle에 대한 프로퍼티
        public bool IsShuffle
        {
            get { return isShuffle; }
            set
            {
                isShuffle = value;
                Player.settings.setMode("Shuffle", value);
            }
        }

        // 위에서 선언한 Enum의 플레이 타입에 따른 프로퍼티
        public PlayerRepeatType RepeatType
        {
            get { return repeatType; }
            set
            {
                repeatType = value;

                // Loop는 노래를 반복
                // AutoRewind는 마지막 곡을 재생했을 때 자동으로 앞 곡을 재생한다.
                switch (repeatType)
                {
                    case PlayerRepeatType.OneTime:
                        Player.settings.setMode("Loop", false);
                        Player.settings.setMode("AutoRewind", false);
                        break;

                    case PlayerRepeatType.Continue:
                        Player.settings.setMode("Loop", true);
                        Player.settings.setMode("AutoRewind", true);
                        break;

                    case PlayerRepeatType.OneMusic:
                        Player.settings.setMode("Loop", false);
                        Player.settings.setMode("AutoRewind", false);
                        break;
                }
            }
        }

        // PlayState에 대한 State 클래스 반환
        public WMPLib.WMPPlayState PlayState
        {
            get { return Player.playState; }
        }

        private void Player_PlayStateChange(int NewState)
        {
            Debug.WriteLine("NewState = " + NewState);

            // 새로운 상태가 Meida가 끝이 난다면
            if (NewState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                Debug.WriteLine("Completed");

                switch (RepeatType)
                {
                    case PlayerRepeatType.OneTime:
                        if (CurrentPlayCount >= MusicList.Count)
                        {
                            CurrentPlayCount = 0;
                            break;
                        }

                        CurrentIndex++;

                     //   Play();
                        break;

                    case PlayerRepeatType.Continue:
                        //   Play();
                        break;

                    case PlayerRepeatType.OneMusic:
                        Debug.WriteLine("one music");
                       
                  //      CurrentPosition = Player.controls.currentPosition = 0;
                        break;
                }
            }
            else  if (NewState == (int)WMPLib.WMPPlayState.wmppsPlaying)
            {
                // 새로운 상태가 다시 재생이 된다면 PlayerForm의 요소들을 변경한다.
                Debug.WriteLine("duration = " + Player.controls.currentItem.duration);
                
                    if (System.Windows.Forms.Application.OpenForms["PlayerForm"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["PlayerForm"] as PlayerForm).SetupMusicControl();
                        (System.Windows.Forms.Application.OpenForms["PlayerForm"] as PlayerForm).backgroundWorker_UpdatepBar.RunWorkerAsync();
                }
            }
        }

        // 현재 미디어를 반환하는 함수
        public WMPLib.IWMPMedia CurrentMedia()
        {
            return Player.controls.currentItem;
        }
        
        // 현재 미디어의 위치를 반환하는 함수
        public double CurrentMediaPosition()
        {
            return Player.controls.currentPosition;
        }

        // 현재 미디어의 총 길이를 반환하는 함수.
        public double CurrentMediaDuration()
        {
            return Player.controls.currentItem.duration;
        }

        // 재생 함수
        public void Play()
        {
            CurrentPlayCount++;

            Player.controls.play();
        }

        // 인덱스에 따른 재생 함수
        public void PlayIndex(int index)
        {
            CurrentPlayCount = 0;

            var m = MusicList.GetMusicByIndex(index);
            if (m != null)
            {
                if (m.MediaFile != null)
                    Player.controls.playItem(m.MediaFile);
            }
        }

        // 해당 위치에 이동하여 재생하는 함수
        public void PlayPosition(double position)
        {
            CurrentPosition = position;
            Player.controls.currentPosition = position;
        }

        // 이전 플레이 함수
        public void PlayPrev()
        {
            // 한 곡만 재생이 아니면 이전곡 재생
            if (RepeatType != PlayerRepeatType.OneMusic)
            {
                Player.controls.previous();
            }
            else
            {
                // 한 곡만 재생이면 해당 위치를 0으로 변경하고 다시 재생
                CurrentPosition = Player.controls.currentPosition = 0;
                Player.controls.play();
            }
        }

        public void PlayNext()
        {
            //  한곡 재생이 아니면 다음 곡을 재생한다.
            if (RepeatType != PlayerRepeatType.OneMusic)
            {
                Player.controls.next();
            }
            else
            {
                // 한곡재생이면 해당 위치를 0으로 변경하고 재생한다.
                CurrentPosition = Player.controls.currentPosition = 0;
                Player.controls.play();
            }
        }

        public void PlayFastForword()
        {
            Player.controls.fastForward();
        }

        public void Stop()
        {
            // 음악을 정지하면 위치를 0으로 바꾸고 정지
            CurrentPosition = 0;
            Player.controls.stop();
            
            // PlayerForm의 이미지를 변경한다.
            (System.Windows.Forms.Application.OpenForms["PlayerForm"] as PlayerForm).btn_PlayToggle.Image = Image.FromFile(Util.Util.GetResourceFullPath("play.png"));
        }

        public void Pause()
        {
            // 일시정지 함수는 일시정지 시에 해당 위치를 기록한다.
            Player.controls.pause();
            CurrentPosition = Player.controls.currentPosition;
        }

        public void Resume()
        {
            // 재생 재개 함수는 이전에 기록해두었던 위치를 대입하여 재생한다.
            Player.controls.currentPosition = CurrentPosition;
            Player.controls.play();
        }

        public void PlaylistAddMusic(Music music)
        {
            // 플레이어 List에 음악을 저장한다.
            MusicList.Add(music);
            music.MediaFile = Player.newMedia(music.DownloadURI);
            Player.currentPlaylist.appendItem(music.MediaFile);
        }

        public void PlayListRemoveMusic(Music music)
        {
            // 플레이어 List에 음악을 삭제한다.
            MusicList.Remove(music);
            if (music.MediaFile != null)
                Player.currentPlaylist.removeItem(music.MediaFile);
        }

        public void PlayListAddMedia(string uri)
        {
            // PlayList에 Media를 추가한다.
            Debug.WriteLine("Uri = " + uri);
            Player.currentPlaylist.appendItem(Player.newMedia(uri));
        }

        // 프로그램 시작 시에 읽어드린 데이터들을 Preset한다.
        public void SetCurrentPlaylist()
        {
            Player.currentPlaylist.clear();

            foreach (var m in musicList.MusicStorage)
            {
                m.MediaFile = Player.newMedia(m.DownloadURI);
                Player.currentPlaylist.appendItem(m.MediaFile);
                Debug.WriteLine("m = " + m.MusicName);
            } 
        }
        
    }
}
