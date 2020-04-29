using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Music
{
    public class MusicList
    {
        private List<Music> musicStorage = new List<Music>();

        public MusicList()
        {

        }
        
        // 음악의 개수를 반환한다.
        public int Count
        {
            get { return musicStorage.Count; }
        }

        // 해당 컨테이너 주소를 반환한다.
        public List<Music> MusicStorage
        {
            get { return musicStorage; }
        }

        // 컨테이너의 인덱스에 저장되어 있는 음악을 반환한다.
        public Music this[int index]
        {
            get { return (musicStorage.Count > index) ? musicStorage[index] : null; }
            set
            {
                if (musicStorage.Count > index)
                    musicStorage[index] = value;
            }
        }

        // 음악을 저장한다.
        public void Add(Music music)
        {
            musicStorage.Add(music);
        }

        // 음악을 삭제한다.
        public void Remove(Music music)
        {
            musicStorage.Remove(music);
        }

        // 데이터베이스 Index를 통하여 음악 파일을 찾아서 반환한다.
        public Music GetMusicByIndex(int index)
        {
            return musicStorage.Find(x => x.Index == index);
        }
    }
}
