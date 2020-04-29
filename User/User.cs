using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.User
{
    public class User
    {
        public int Index { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsShuffle { get; set; }
        public Music.PlayerRepeatType RepeatType { get; set; }
        public List<int> PlayList { get; set; }
        public List<int> FavorateList { get; set; }
        public int LastPlayMusic { get; set; }
        public bool IsLogin { get; set; }

        // 유저를 관리하기 위한 클래스
        public User(int index, string username, string password, bool is_shuffle = false, Music.PlayerRepeatType repeat_type = Music.PlayerRepeatType.OneTime, bool isLogin = false)
        {
            Index = index; // 데이터베이스 Index
            Username = username; // 유저이름
            Password = password; // 패스워드
            IsShuffle = is_shuffle; // 랜덤재생
            RepeatType = repeat_type; // 플레이 타입
            PlayList = new List<int>(); // PlayList
            FavorateList = new List<int>(); // FavorateList
            IsLogin = isLogin; // 로그인 여부
        }

        ~User()
        {
            Database.Database.Instance.SaveUserData(this);
        }
    }
}
