using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Util
{
    class Util
    {
        private static volatile Util instance;
        private static object syncRoot = new object();

        public static Util Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Util();
                    }
                }

                return instance;
            }
        }

        // User의 저장하는 데이터들은 1,2,3,4, 등의 형식으로 저장된다.
        
        // 아래의 함수는 위와 같은 문자열을 파싱하여 List<int> 타입으로 변경하는 함수이다.
        public static List<int> ParseMusicListFromString(string s)
        {
            // 문자열이 비어있으면 빈 리스트를 반환한다.
            if (s == "")
                return new List<int>();

            // 문자열을 ,로 나누어서 해당 데이터를 int형으로 파싱한 뒤에 그 데이터들을 List로 변환한다.
            return s.Split(',').Select(x => int.Parse(x)).ToList();
        }

        // 아래의 함수는 위의 함수에서 만들어진 List<int>를 다시 문자열로 만들어주는 함수이다.
        public static string MakeMusicListStringFromList(List<int> musicList)
        {
            // 리스트가 비어있으면 빈 문자열을 반환한다.
            if (musicList.Count <= 0)
                return "";

            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < musicList.Count; ++i)
            {
                // 마지막 문자열이면 ,을 넣지 않는다.
                if (i == musicList.Count - 1)
                    sb.Append(musicList[i].ToString());
                else
                    sb.AppendFormat("{0},", musicList[i].ToString());
            }

            return sb.ToString();
        }

        public static Music.MusicList MakeMusicListFromIndexList(Music.MusicList musiclist, List<int> indexis)
        {
            Music.MusicList music = new Music.MusicList();

            indexis.ForEach(x =>
            {
                var item = musiclist.GetMusicByIndex(x);
                if (item != null)
                    music.Add(new Music.Music(item));
            });

            return music;
        }

        // 리소스 파일의 경로를 반환해주는 함수이다.
        public static string GetResourceFullPath(string filename)
        {
            StringBuilder sb = new StringBuilder(Path.GetFullPath("Res"));
            sb.AppendFormat("\\{0}", filename); 

            return sb.ToString();
        }
    }
}
