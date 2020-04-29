using MusicPlayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class PlayerForm : Form
    {
        private User.User userSession;

        public PlayerForm(User.User user)
        {
            InitializeComponent();

            // LoginForm에서 얻은 UserSession을 이용한다.
            this.userSession = user;

            this.Resize += PlayerForm_Resize;
            this.FormClosed += PlayerForm_FormClosed;
        }

        private void PlayerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 폼을 닫기 전에 마지막으로 재생된 미디어를 얻어내어 해당 미디어의 인덱스를 얻은 뒤에 LastPlayMusic에 기록한다.
            var CurrentMedia = Music.MusicPlayer.Instance.CurrentMedia();
            Music.Music music = Music.MusicPlayer.Instance.MusicList.MusicStorage.Find(x => x.MusicName == CurrentMedia.name || x.Index.ToString() == CurrentMedia.name);
            userSession.LastPlayMusic = music.Index;
        }

        private void PlayerForm_Resize(object sender, EventArgs e)
        {
            // 프로그램의 상태가 Normal이면 알림 아이콘을 숨기고 프로그램을 보인다.
            if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon_Hide.Visible = false;
                this.ShowInTaskbar = true;
            }
            // 프로그램의 상태가 최소화 상태이면 아이콘을 나타내고 프로그램을 숨긴다.
            else if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon_Hide.Visible = true;
                this.Hide();
            }
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            // 폼을 로딩할 때에 컴포넌트들을 설정한다.
            SetupMusicComponent();
            SetupControl();
        }

        private void SetupMusicComponent()
        {
            // 프로그램이 시작될 때 데이터베이스로부터 음악파일을 요청한다.
            Database.Database.Instance.RequestMusicList();

            // 해당 파일들을 ListView에 삽입한다.
            if (Database.Database.Instance.MusicList != null)
            {
                foreach (var music in Database.Database.Instance.MusicList.MusicStorage)
                {
                    ListViewItem item = new ListViewItem(music.Index.ToString());
                    item.SubItems.Add(music.MusicName);
                    item.SubItems.Add(music.Artist);
                    item.SubItems.Add(music.Album);
                    listView_MusicList.Items.Add(item);
                }
            }

            // 얻어낸 UserSession을 통한 초기 설정
            Music.MusicPlayer.Instance.IsShuffle = userSession.IsShuffle;
            Music.MusicPlayer.Instance.RepeatType = userSession.RepeatType;

            // PlaList에 대한 데이터를 통해 MusicList에 음악을 저장한다.
            foreach (var index in userSession.PlayList)
            {
                var item = Database.Database.Instance.MusicList.GetMusicByIndex(index);
                listView_Playlist.Items.Add(MakeMusicListViewItem(item));
                Music.MusicPlayer.Instance.MusicList.Add(new Music.Music(item));
            }

            // PlayList를 설정한다.
            Music.MusicPlayer.Instance.SetCurrentPlaylist();
        }

        private void SetupControl()
        {
            // label_Hello
            this.label_Hello.Text = "안녕하세요. " + userSession.Username + "님";

            // notifyIcon_Hide
            this.notifyIcon_Hide.MouseDoubleClick += notifyIcon_Hide_MouseDoubleClick;

            // txtBox_Search
            this.txtBox_Search.KeyDown += txtBox_Search_KeyDown;

            // toolStripMenuItem
            this.toolStripMenuItem_Play.Click += (s, e) =>
            {
                // PlayList 화면에서 음악을 재생 버튼을 클릭했을 때 재생한다.
                if (listView_Playlist.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView_Playlist.SelectedItems[0];
                    int index = int.Parse(item.Text);
                    Music.MusicPlayer.Instance.Stop();
                    Music.MusicPlayer.Instance.PlayIndex(index);
                    btn_PlayToggle.Image = Image.FromFile(Util.Util.GetResourceFullPath("pause.png"));
                }
            };

            this.toolStripMenuItem_Delete.Click += (s, e) =>
            {
                // PlayList 화면에서 음악을  삭제 버튼을 클릭했을 때 삭제한다.
                if (listView_Playlist.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView_Playlist.SelectedItems[0];
                    int index = int.Parse(item.Text);
                    Music.Music music = Music.MusicPlayer.Instance.MusicList[0];
                    listView_Playlist.Items.Remove(item);
                    userSession.PlayList.Remove(index);

                        if (userSession.LastPlayMusic == index)
                        {
                            userSession.LastPlayMusic = 0;
                        }

                    Music.MusicPlayer.Instance.PlayListRemoveMusic(music);
                }
            };

            // 음악 재생의 ProgressBar와 시간의 변경을 위한 BackgroundWorker
            // backgroundWorker
            this.backgroundWorker_UpdatepBar.DoWork += BackgroundWorker_UpdatepBar_DoWork;
            this.backgroundWorker_UpdatepBar.ProgressChanged += BackgroundWorker_UpdatepBar_ProgressChanged;

            // listView_Musiclist
            this.listView_MusicList.DrawItem += listView_MusicList_DrawItem;
            this.listView_MusicList.DrawSubItem += listview_MusicList_DrawSubItem;
            this.listView_MusicList.MouseHover += listView_MusicList_MouseHover;
            this.listView_MusicList.MouseMove += listView_MusicList_MouseMove;
            this.listView_MusicList.MouseDoubleClick += listView_MusicList_MouseDoubleClick;

            // listView_Favorate
            this.listView_Favorate.DrawItem += ListView_Favorate_DrawItem;
            this.listView_Favorate.DrawSubItem += ListView_Favorate_DrawSubItem;
            this.listView_Favorate.MouseDoubleClick += listView_Favorate_MouseDoubleClick;

            // listView_Playlist
            this.listView_Playlist.DrawItem += listView_MusicList_DrawItem;
            this.listView_Playlist.DrawSubItem += listview_MusicList_DrawSubItem;
            this.listView_Playlist.MouseDoubleClick += listView_Playlist_MouseDoubleClick;
            this.listView_Playlist.DragLeave += listView_Playlist_DragLeave;

            // listView_Search
            this.listView_Search.DrawItem += listView_MusicList_DrawItem;
            this.listView_Search.DrawSubItem += listview_MusicList_DrawSubItem;
            this.listView_Search.MouseDoubleClick += listView_Search_MouseDoubleClick;

            // btn_Fravorate
            this.btn_Favorate.FlatAppearance.MouseOverBackColor = btn_Favorate.BackColor;
            this.btn_Favorate.BackColorChanged += (s, e) =>
            {
                btn_Favorate.FlatAppearance.MouseOverBackColor = btn_Favorate.BackColor;
                btn_Favorate.FlatAppearance.MouseDownBackColor = btn_Favorate.BackColor;
            };
            this.btn_Favorate.FlatAppearance.MouseDownBackColor = btn_Favorate.BackColor;

            this.btn_Favorate.Click += (s, e) =>
            {
                // Favorate를 클릭했을 때 해당 미디어를 얻어내어 Music의 값을 얻어낸다.
                var CurrentMedia = Music.MusicPlayer.Instance.CurrentMedia();
                Music.Music music = Music.MusicPlayer.Instance.MusicList.MusicStorage.Find(x => x.MusicName == CurrentMedia.name || x.Index.ToString() == CurrentMedia.name);
                if (music != null)
                {
                    // Music값을 토대로 유저데이터가 이 음악을 즐겨찾기 했는 지 체크하고 추가했으면 삭제하고 삭제를 했으면 추가한다.
                    int index = music.Index;
                    bool isFavorate = userSession.FavorateList.Contains(index);

                    if (!isFavorate)
                    {
                        //
                        btn_Favorate.Image = Image.FromFile(Util.Util.GetResourceFullPath("like.png"));
                        userSession.FavorateList.Add(index);
                    }
                    else
                    {
                        btn_Favorate.Image = Image.FromFile(Util.Util.GetResourceFullPath("unlike.png"));
                        userSession.FavorateList.Remove(index);
                    }
                }
            };

            // 랜덤재생 이미지에 대한 초기 설정
            // btn_shuffle
            if (userSession.IsShuffle)
            {
                btn_Shuffle.Image = Image.FromFile(Util.Util.GetResourceFullPath("shuffle.png"));
            }
            else
            {
                btn_Shuffle.Image = Image.FromFile(Util.Util.GetResourceFullPath("no_shuffle.png"));
            }

            this.btn_Shuffle.Click += (s, e) =>
            {
                // 랜덤 재생을 클릭했을 때 이미지를 설정하고 해당 값을 토글한다.
                if (!userSession.IsShuffle)
                {
                    btn_Shuffle.Image = Image.FromFile(Util.Util.GetResourceFullPath("shuffle.png"));
                    Music.MusicPlayer.Instance.IsShuffle = userSession.IsShuffle = true;
                }
                else
                {
                    btn_Shuffle.Image = Image.FromFile(Util.Util.GetResourceFullPath("no_shuffle.png"));
                    Music.MusicPlayer.Instance.IsShuffle = userSession.IsShuffle = false;
                }

                //    Music.MusicPlayer.Instance.SetCurrentPlaylist();
            };

            // RepeatType에 대한 초기 설정
            // btn_Repate
            switch (userSession.RepeatType)
            {
                case Music.PlayerRepeatType.OneTime:
                    btn_Repeate.Image = Image.FromFile(Util.Util.GetResourceFullPath("onetime.png"));
                    break;

                case Music.PlayerRepeatType.Continue:
                    btn_Repeate.Image = Image.FromFile(Util.Util.GetResourceFullPath("repeat.png"));
                    break;

                case Music.PlayerRepeatType.OneMusic:
                    btn_Repeate.Image = Image.FromFile(Util.Util.GetResourceFullPath("one_repeat.png"));
                    break;
            }

            this.btn_Repeate.Click += (s, e) =>
            {
                // Repeat Type을 클릭했을 때 값을 계속 증가시키며 값이 Music보다 커지면 다시 0으로 설정한다.
                if (++userSession.RepeatType > Music.PlayerRepeatType.OneMusic)
                    userSession.RepeatType = Music.PlayerRepeatType.OneTime;

                // 음악 플레이어에 대한 설정을 변경한다.
                Music.MusicPlayer.Instance.RepeatType = userSession.RepeatType;

                // 해당 타입에 따른 이미지를 변경한다.
                switch (userSession.RepeatType)
                {
                    case Music.PlayerRepeatType.OneTime:
                        btn_Repeate.Image = Image.FromFile(Util.Util.GetResourceFullPath("onetime.png"));
                        break;

                    case Music.PlayerRepeatType.Continue:
                        btn_Repeate.Image = Image.FromFile(Util.Util.GetResourceFullPath("repeat.png"));
                        break;

                    case Music.PlayerRepeatType.OneMusic:
                        btn_Repeate.Image = Image.FromFile(Util.Util.GetResourceFullPath("one_repeat.png"));
                        break;
                }

                //   Music.MusicPlayer.Instance.SetCurrentPlaylist();
            };

            this.checkBox_Shuffle.CheckedChanged += checkBox_Shuffle_CheckedChanged;

            this.radioButton_OneTime.CheckedChanged += RadioButton_OneTime_CheckedChanged;
            this.radioButton_Repeat.CheckedChanged += RadioButton_Repeat_CheckedChanged;
            this.radioButton_RepeatOne.CheckedChanged += RadioButton_RepeatOne_CheckedChanged;

            // SeekBar
            this.pBar_Media.Click += pBar_Media_Click;

            // 마지막 값이 0이 아니라면 컨트롤을 설정한다.
            // MusicControlPanel
            if (userSession.LastPlayMusic != 0)
            {
                SetupMusicControl(userSession.LastPlayMusic);
            }

        }

        // 3가지의 라디오 버튼을 통해 Repeat 타입을 설정하여 해당 값이 체크되어 있으면 이미지를 변경하고 Repeat 타입을 변경한다.
        private void RadioButton_RepeatOne_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_RepeatOne.Checked == true)
            {
                btn_Repeate.Image = Image.FromFile(Util.Util.GetResourceFullPath("one_repeat.png"));
                userSession.RepeatType = Music.MusicPlayer.Instance.repeatType = Music.PlayerRepeatType.OneMusic;
            }
        }

        private void RadioButton_Repeat_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Repeat.Checked == true)
            {
                btn_Repeate.Image = Image.FromFile(Util.Util.GetResourceFullPath("repeat.png"));
                userSession.RepeatType = Music.MusicPlayer.Instance.repeatType = Music.PlayerRepeatType.Continue;
            }
        }

        private void RadioButton_OneTime_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_OneTime.Checked == true)
            {
                btn_Repeate.Image = Image.FromFile(Util.Util.GetResourceFullPath("onetime.png"));
                userSession.RepeatType = Music.MusicPlayer.Instance.repeatType = Music.PlayerRepeatType.OneTime;
            }
        }

        // Checkbox의 랜덤 재생을 변경되었을 때 값이 바뀌면 플레이어의 랜덤재생 값도 변경하고 이미지를 변경한다.
        private void checkBox_Shuffle_CheckedChanged(object sender, EventArgs e)
        {
            if (!userSession.IsShuffle)
            {
                btn_Shuffle.Image = Image.FromFile(Util.Util.GetResourceFullPath("shuffle.png"));
            }
            else
            {
                btn_Shuffle.Image = Image.FromFile(Util.Util.GetResourceFullPath("no_shuffle.png"));
            }

            Music.MusicPlayer.Instance.IsShuffle = userSession.IsShuffle = checkBox_Shuffle.Checked;
        }

        // 알림 아이콘을 눌렀을 때 폼을 나타내고 상태를 바꾼다.
        private void notifyIcon_Hide_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void listView_Playlist_DragLeave(object sender, EventArgs e)
        {

        }

        // textBox_Search에서 키를 눌렀을 때 Enter키를 체크하고 Enter키라면 데이터를 검색하여 Listview에 추가한다.
        private void txtBox_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listView_Search.Items.Clear();
                foreach (var music in Database.Database.Instance.MusicList.MusicStorage)
                {
                    if (music.MusicName.Contains(txtBox_Search.Text))
                    {
                        var item = MakeMusicListViewItem(music);
                        listView_Search.Items.Add(item);
                    }
                }

                label_SearchResult.Text = "총 " + listView_Search.Items.Count.ToString() + "개의 검색 결과가 있습니다.";
            }
        }

        // PlayList에서 음악을 클릭하면 해당 음악을 재생한다.
        private void listView_Playlist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_Playlist.SelectedItems.Count > 0)
            {
                int index = int.Parse(listView_Playlist.SelectedItems[0].Text);
                Music.MusicPlayer.Instance.Stop();
                Music.MusicPlayer.Instance.PlayIndex(index);
                btn_PlayToggle.Image = Image.FromFile(Util.Util.GetResourceFullPath("pause.png"));
            }
        }

        // 현재 음악에 대한 데이터들을 레이아웃(앨범커버, 음악 이름, 작곡가 이름 등)에 값을 설정한다.
        public void SetupMusicControl()
        {
            var CurrentMedia = Music.MusicPlayer.Instance.CurrentMedia();
            Music.Music music = Music.MusicPlayer.Instance.MusicList.MusicStorage.Find(x => x.MusicName == CurrentMedia.name || x.Index.ToString() == CurrentMedia.name);
            picBox_AlbumThumnail.Image = music.AlbumImage;
            label_MusicName.Text = music.MusicName + " - " + music.Artist;
            label_Album.Text = music.Album;
            TimeSpan t = TimeSpan.FromSeconds(music.Duration);
            label_Duration.Text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            pBar_Media.Maximum = (int)music.Duration;
            trackBar1.Maximum = (int)music.Duration;

            bool favorate = userSession.FavorateList.Contains(music.Index);
            if (favorate)
            {
                btn_Favorate.Image = Image.FromFile(Util.Util.GetResourceFullPath("like.png"));
            }
            else
            {
                btn_Favorate.Image = Image.FromFile(Util.Util.GetResourceFullPath("unlike.png"));
            }
        }

        // 아래의 함수는 MusicList에 저장되어있는 index를 통한 데이터들을 설정한다
        public void SetupMusicControl(int index)
        {
            Music.Music music = Music.MusicPlayer.Instance.MusicList.GetMusicByIndex(index);
            picBox_AlbumThumnail.Image = music.AlbumImage;
            label_MusicName.Text = music.MusicName + " - " + music.Artist;
            label_Album.Text = music.Album;
            TimeSpan t = TimeSpan.FromSeconds(music.Duration);
            label_Duration.Text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            pBar_Media.Maximum = (int)music.Duration;
            trackBar1.Maximum = (int)music.Duration;

            bool favorate = userSession.FavorateList.Contains(music.Index);
            if (favorate)
            {
                btn_Favorate.Image = Image.FromFile(Util.Util.GetResourceFullPath("like.png"));
            }
            else
            {
                btn_Favorate.Image = Image.FromFile(Util.Util.GetResourceFullPath("unlike.png"));
            }
        }

        // Favorate List에 대해 Item을 그리는 함수
        private void ListView_Favorate_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            int index = e.ItemIndex;

            // 해당 아이템이 클릭이 되어 있으면 사각형으로 채운다.
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                e.DrawFocusRectangle();
            }

            // 맨 첫번째 열에 앨범 커버를 그린다.
            int musicIndex = int.Parse(e.Item.Text);
            var imageRect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 40, 40);
            var image = Database.Database.Instance.MusicList.GetMusicByIndex(musicIndex).AlbumImage;
            Debug.WriteLine("Data = " + e.Item.Text);
            e.Graphics.DrawImage(image, imageRect, new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            //   e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft);
        }

        // Favorate List에 대해 SubItem을 그리는 함수
        private void ListView_Favorate_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 0)
                return;

            // Sub 열에 대해 텍스트로 나타낸다.
            e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft);
        }

        private void BackgroundWorker_UpdatepBar_DoWork(object sender, DoWorkEventArgs e)
        {
            int position = 0;
            // 음악이 재생될 때 계속 반복한다.
            while (Music.MusicPlayer.Instance.PlayState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                position = (int)(Music.MusicPlayer.Instance.CurrentMediaPosition());
                Debug.WriteLine("position = " + position + " current = " + (int)Music.MusicPlayer.Instance.CurrentMediaDuration());
                if (position == (int)Music.MusicPlayer.Instance.CurrentMediaDuration() - 1)
                {
                    if (Music.MusicPlayer.Instance.repeatType == Music.PlayerRepeatType.OneMusic)
                    {
                        Music.MusicPlayer.Instance.CurrentPosition = 0;
                        return;
                    }
                }
                // 해당 위치에 대한 값을 얻어내어 미디어의 소요시간과 비교하여 끝일 때 반복 설정이 한곡반복이면 다시 처음으로 재생한다.

                // BackgroundWorker에서 컨트롤을 변경하기 위해 해당 함수를 호출한다.
                backgroundWorker_UpdatepBar.ReportProgress(position);

                Thread.Sleep(1000);
            }
        }

        private void BackgroundWorker_UpdatepBar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 위에서 넘겨준 매개변수를 통해 음악 경과 시간을 변경한다.
            int progress = e.ProgressPercentage;
            pBar_Media.Value = progress;
            TimeSpan t = TimeSpan.FromSeconds(Music.MusicPlayer.Instance.CurrentMediaPosition());
            label_CurrentPos.Text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        }

        private void btn_PlayToggle_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Media state = " + Music.MusicPlayer.Instance.PlayState);

            // Play 버튼을 재생했을 때 상태에 따라 재생을 달리하여 호출한다.
            switch (Music.MusicPlayer.Instance.PlayState)
            {
                case WMPLib.WMPPlayState.wmppsUndefined:
                case WMPLib.WMPPlayState.wmppsReady:
                    Music.MusicPlayer.Instance.Play();
                    btn_PlayToggle.Image = Image.FromFile(Util.Util.GetResourceFullPath("pause.png"));
                    break;

                case WMPLib.WMPPlayState.wmppsPlaying:
                    Music.MusicPlayer.Instance.Pause();
                    btn_PlayToggle.Image = Image.FromFile(Util.Util.GetResourceFullPath("play.png"));
                    break;

                case WMPLib.WMPPlayState.wmppsPaused:
                    Music.MusicPlayer.Instance.Resume();
                    btn_PlayToggle.Image = Image.FromFile(Util.Util.GetResourceFullPath("pause.png"));
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Music.MusicPlayer.Instance.PlayFastForword();
        }

        // 이전 재생 버튼 함수
        private void btn_PlayPrev_Click(object sender, EventArgs e)
        {
            Music.MusicPlayer.Instance.PlayPrev();
            
            // 음악이 Play 될 때 SetupMusicControl 함수와 겹치지 않기 위해 해당 상태일 때만 변경한다.
            if (Music.MusicPlayer.Instance.PlayState == WMPLib.WMPPlayState.wmppsReady || Music.MusicPlayer.Instance.PlayState == WMPLib.WMPPlayState.wmppsTransitioning)
                SetupMusicControl();
        }

        // 다음 재생 함수
        private void btn_PlayNext_Click(object sender, EventArgs e)
        {
            Music.MusicPlayer.Instance.PlayNext();

            // 음악이 Play 될 때 SetupMusicControl 함수와 겹치지 않기 위해 해당 상태일 때만 변경한다.
            if (Music.MusicPlayer.Instance.PlayState == WMPLib.WMPPlayState.wmppsReady || Music.MusicPlayer.Instance.PlayState == WMPLib.WMPPlayState.wmppsTransitioning)
                SetupMusicControl();
        }

        private void listView_MusicList_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void listView_MusicList_MouseHover(object sender, EventArgs e)
        {

        }

        // MusicList ListView에 대한 Item Draw
        private void listView_MusicList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            int index = e.ItemIndex;

            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                e.DrawFocusRectangle();
            }

            int musicIndex = int.Parse(e.Item.Text);
            var image = Database.Database.Instance.MusicList.GetMusicByIndex(musicIndex).AlbumImage;
            var imageRect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 40, 40);
            e.Graphics.DrawImage(image, imageRect, new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            //   e.DrawText(TextFormatFlags.VerticalCenter);
        }

        // MusicList ListView에 대한 SubItem Draw
        private void listview_MusicList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 0)
                return;

            if ((e.ItemState & ListViewItemStates.Selected) != 0)
            {
                e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, Brushes.White, e.Bounds.X + 10, e.Bounds.Y + 20);
            //    e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft);
            }
            else
            {
                e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft);
            }
            
        }

        // MusicList에 해당 아이템을 눌렀을 때 PlayList로 데이터를 추가한다.
        private void listView_MusicList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_MusicList.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView_MusicList.SelectedItems)
                {
                    int index = int.Parse(item.Text);
                    var m = Database.Database.Instance.MusicList.GetMusicByIndex(index);
                    if (m != null)
                    {
                        userSession.PlayList.Add(index);
                        Music.MusicPlayer.Instance.PlaylistAddMusic(new Music.Music(m));
                        listView_Playlist.Items.Add(MakeMusicListViewItem(m));
                    }
                }  
            }
        }

        // SearchList에 해당 아이템을 눌렀을 때 PlayList로 데이터를 추가한다.
        private void listView_Search_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_Search.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView_Search.SelectedItems)
                {
                    int index = int.Parse(item.Text);
                    var m = Database.Database.Instance.MusicList.GetMusicByIndex(index);
                    if (m != null)
                    {
                        userSession.PlayList.Add(index);
                        Music.MusicPlayer.Instance.PlaylistAddMusic(new Music.Music(m));
                        listView_Playlist.Items.Add(MakeMusicListViewItem(m));
                    }
                }
            }
        }

        // Favorate List에서 해당 아이템을 눌렀을 때 PlayList로 데이터를 추가한다.
        private void listView_Favorate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_Favorate.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView_Favorate.SelectedItems)
                {
                    int index = int.Parse(item.Text);
                    var m = Database.Database.Instance.MusicList.GetMusicByIndex(index);
                    if (m != null)
                    {
                        userSession.PlayList.Add(index);
                        Music.MusicPlayer.Instance.PlaylistAddMusic(new Music.Music(m));
                        listView_Playlist.Items.Add(MakeMusicListViewItem(m));
                    }
                }
            }
        }

        // ProgressBar에서 해당 위치를 눌렀을 때 음악을 해당 위치로 이동한다.
        private void pBar_Media_Click(object sender, EventArgs e)
        {
            Point CP = pBar_Media.PointToClient(Cursor.Position);
            pBar_Media.Value = pBar_Media.Minimum + (pBar_Media.Maximum - pBar_Media.Minimum) * CP.X / pBar_Media.Width;
            Music.MusicPlayer.Instance.PlayPosition((int)pBar_Media.Value);
        }

        private void mediaTrackBar1_Scroll(object sender, EventArgs e)
        {

        }

        // 탭에 따라 탭을 눌렀을 때 해당 선택된 탭에 따라 처리하는 함수
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                // Top 100
                case 0:
                  //  listView_Favorate.Items.Clear();
                    break;

                // Music list
                case 1:
                 //   listView_Favorate.Items.Clear();
                    break;

                // like this
                case 2:
                    {
                        // 즐겨찾기 버튼을 눌렀을 때 유저세션에 저장된 FavorateList의 값을 얻어내어 즐겨찾기한 음악들을 출력한다.
                        var musicList = Database.Database.Instance.MusicList;
                        Debug.WriteLine("Like list");

                        listView_Favorate.Items.Clear();

                        userSession.FavorateList.ForEach(x =>
                        {
                            var music = musicList.GetMusicByIndex(x);

                            if (music != null)
                            {
                                Debug.WriteLine("Music Name = " + music.MusicName);
                                ListViewItem item = new ListViewItem(music.Index.ToString());
                                item.SubItems.Add(music.MusicName);
                                item.SubItems.Add(music.Artist);
                                item.SubItems.Add(music.Album);
                                //    item.SubItems.Add("0");
                                listView_Favorate.Items.Add(item);

                                Debug.WriteLine("Uri = " + music.DownloadURI);
                            }
                        });
                    }

                    Debug.WriteLine("listView = " + listView_Favorate.Items.Count);
                    break;

                //
                case 3:
                    break;

                case 4:
                    // 설정 아이콘을 눌렀을 때 설정에 따른 초기값을 설정한다.
                    this.label_Username.Text = userSession.Username;
                    this.label_Password.Text = new string(userSession.Password.Select(x => '*').ToArray());

                    checkBox_Shuffle.Checked = userSession.IsShuffle;

                    switch (userSession.RepeatType)
                    {
                        case Music.PlayerRepeatType.OneTime:
                            radioButton_OneTime.Checked = true;
                            break;

                        case Music.PlayerRepeatType.Continue:
                            radioButton_Repeat.Checked = true;
                            break;

                        case Music.PlayerRepeatType.OneMusic:
                            radioButton_RepeatOne.Checked = true;
                            break;
                    }

                    break;
            }
        }

        // Music 아이템에 대해 ListViewItem으로 생성하여 반환한다.
        private ListViewItem MakeMusicListViewItem(Music.Music music)
        {
            ListViewItem item = new ListViewItem(music.Index.ToString());
            item.SubItems.Add(music.MusicName);
            item.SubItems.Add(music.Artist);
            item.SubItems.Add(music.Album);
            return item;
        }
    }
}
