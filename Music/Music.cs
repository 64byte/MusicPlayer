using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Music
{
    public class Music
    {
        public int Index { get; set; }
        public string MusicName { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string DownloadURI { get; set; }

        // Image를 캐싱하여 앨범 커버를 사용한다.
        public Image AlbumImage { get; set; }
        public int Duration { get; set; }

        // WMPLib에 사용되는 Media
        public WMPLib.IWMPMedia MediaFile { get; set; }

        public Music(int index, string musicname, string artist, string album, string downloaduri)
        {
            this.Index = index;
            this.MusicName = musicname;
            this.Artist = artist;
            this.Album = album;
            this.DownloadURI = downloaduri;

            // 태그 라이브러리를 사용하여 해당 파일에 대해 id3Tag의 값을 읽어온다.
            TagLib.File tagFile = TagLib.File.Create(downloaduri);
            MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
            AlbumImage = System.Drawing.Image.FromStream(ms);
            
            Duration = (int)tagFile.Properties.Duration.TotalSeconds;
        }

        public Music(Music music)
        {
            this.Index = music.Index;
            this.MusicName = music.MusicName;
            this.Artist = music.Artist;
            this.Album = music.Album;
            this.DownloadURI = music.DownloadURI;

            TagLib.File tagFile = TagLib.File.Create(this.DownloadURI);
            MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
            AlbumImage = System.Drawing.Image.FromStream(ms);

            Duration = (int)tagFile.Properties.Duration.TotalSeconds;
        }
    }
}
