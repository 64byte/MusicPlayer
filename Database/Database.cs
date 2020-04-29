using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;

namespace MusicPlayer.Database
{
    public class Database
    {
        // for singleton
        private static volatile Database instance;
        private static object syncRoot = new object();

        // for class
        private const string ConnParameter = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MusicPlayer.mdb";
        private DataSet DbDataSet = new DataSet();
        OleDbConnection Connection;
        public Music.MusicList musicList = new Music.MusicList();
        public int LastIndexId = 0;

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Database();
                    }
                }

                return instance;
            }
        }

        public Database()
        {
            try {
                // Connection을 생성하고 Adapter를 통한 DataSet을 채워넣는다.
                Connection = new OleDbConnection(ConnParameter);

                Connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand("select * from UserInfo", Connection);
                adapter.Fill(DbDataSet, "UserInfo");
                OleDbDataAdapter adapters = new OleDbDataAdapter();
                adapters.SelectCommand = new OleDbCommand("select * from MusicList", Connection);
                adapters.Fill(DbDataSet, "MusicList");

                Connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Database() = " + e.Message);
            }
        }

        ~Database()
        {

        }

        public Music.MusicList MusicList
        {
            get { return musicList; }
        }

        public void UpdateUserInfo()
        {
            try
            {
                // 해당 명령어들에 대해 갱신하여 DataSet을 업데이트한다.
                Connection.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter("select * from UserInfo", Connection);
                adapter.InsertCommand = new OleDbCommandBuilder(adapter).GetInsertCommand();
//                adapter.UpdateCommand = new OleDbCommandBuilder(adapter).GetUpdateCommand();
                adapter.DeleteCommand = new OleDbCommandBuilder(adapter).GetDeleteCommand();

                adapter.Update(DbDataSet, "UserInfo");

                new OleDbCommandBuilder(adapter).Dispose();
                Connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public bool RegisterUserData(User.User user)
        {
            try {
                // UserInfo에 대한 DataRow를 생성하여 데이터를 채워넣는다.
                DataRow row = DbDataSet.Tables["UserInfo"].NewRow();
                row["ID"] = user.Index;
                row["Username"] = user.Username;
                row["Password"] = user.Password;
                row["IsShuffle"] = user.IsShuffle;
                row["RepeatType"] = user.RepeatType.ToString();
                row["LastPlayMusic"] = user.LastPlayMusic;
//                row["IsLogin"] = user.IsLogin;
                DbDataSet.Tables["UserInfo"].Rows.Add(row);

                // 채워넣은 데이터들에 대해 쿼리 명령어를 이용하여 DataSet에 데이터를 삽입한다.
                Connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.InsertCommand = new OleDbCommand("Insert into [UserInfo] ([ID], [Username],[Password],[IsShuffle],[RepeatType], [LastPlayMusic]) values (@ID, @Username,@Password,@IsShuffle,@RepeatType, @LastPlayMusic)", Connection);
                adapter.InsertCommand.Parameters.Add("@ID", OleDbType.Integer, 0, "ID");
                adapter.InsertCommand.Parameters.Add("@Username", OleDbType.Char, 20, "Username");
                adapter.InsertCommand.Parameters.Add("@Password", OleDbType.Char, 20, "Password");
                adapter.InsertCommand.Parameters.Add("@IsShuffle", OleDbType.Boolean, 0, "IsShuffle");
                adapter.InsertCommand.Parameters.Add("@RepeatType", OleDbType.Char, 20, "RepeatType");
                adapter.InsertCommand.Parameters.Add("@LastPlayMusic", OleDbType.Integer, 0, "LastPlayMusic");
                adapter.Update(DbDataSet, "UserInfo");
                Connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("MakeUserData = " + e.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return true;
        }

        public User.User GetUserInfoByName(string username)
        {
            try {
                // 해당 테이블에 대해 쿼리문을 수행하여 값을 찾아낸다.
                var rows = DbDataSet.Tables["UserInfo"].Select("Username='" + username + "'", null, DataViewRowState.CurrentRows);
                if (rows.Count() > 0)
                {
                    var user = new User.User(int.Parse(rows[0]["ID"].ToString()), rows[0]["Username"].ToString(), rows[0]["Password"].ToString(), bool.Parse(rows[0]["IsShuffle"].ToString()), (Music.PlayerRepeatType)Enum.Parse(typeof(Music.PlayerRepeatType), rows[0]["RepeatType"].ToString()));

                    user.LastPlayMusic = int.Parse(rows[0]["LastPlayMusic"].ToString());
                    user.FavorateList = Util.Util.ParseMusicListFromString(rows[0]["FavorateList"].ToString());
                    user.PlayList = Util.Util.ParseMusicListFromString(rows[0]["PlayList"].ToString());

                    return user;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetUSerInfoByName = " + e.Message);
            }

            return null;
        }

        public bool IsRegsistedUser(string username)
        {
            // UserInfo 테이블에 Username과 일치하는 데이터를 찾아낸다.
            var rows = DbDataSet.Tables["UserInfo"].Select("Username='" + username + "'", null, DataViewRowState.CurrentRows);

            // 갯수가 0보다 크면 true를 반환하고 아니면 false를 반환한다.
            if (rows.Count() > 0)
            {
                return true;
            }

            return false;
        }

        // 해당 테이블의 마지막 Index를 얻어낸다.
        public int GetLastIndex()
        {
            return DbDataSet.Tables["UserInfo"].Rows.Count;
        }

        public User.User LoginRequest(string username, string password)
        {
            // 해당 테이블에서 Usernmae과 Password가 일치하는 데이터를 찾아낸다.
            var rows = DbDataSet.Tables["UserInfo"].Select("Username='" + username + "' AND Password='" + password + "'", null, DataViewRowState.CurrentRows);

            // 찾아낸 데이터가 0보다 크면 로그인이 성공한 것으로 간주한다.
            if (rows.Count() > 0)
            {
                var user = new User.User(int.Parse(rows[0]["ID"].ToString()), rows[0]["Username"].ToString(), rows[0]["Password"].ToString(), bool.Parse(rows[0]["IsShuffle"].ToString()), (Music.PlayerRepeatType)Enum.Parse(typeof(Music.PlayerRepeatType), rows[0]["RepeatType"].ToString()));
                
                user.LastPlayMusic = int.Parse(rows[0]["LastPlayMusic"].ToString());
                user.FavorateList = Util.Util.ParseMusicListFromString(rows[0]["FavorateList"].ToString());
                user.PlayList = Util.Util.ParseMusicListFromString(rows[0]["PlayList"].ToString());

                return user;
            }

            return null;
        }

        public void SaveUserData(User.User user)
        {
            try
            {
                // 해당 테이블에 대해 Index가 같은 rows를 찾아낸다.
                var rows = DbDataSet.Tables["UserInfo"].Select("ID='" + user.Index + "'", null, DataViewRowState.CurrentRows);
                if (rows != null)
                {
                    DataRow row = rows[0]; // 찾아낸 row를 통해 데이터를 수정한다.
                    if (row != null)
                    {
                        Debug.WriteLine("여기 = " + row["Username"].ToString());
                        row["ID"] = user.Index;
                        row["IsShuffle"] = user.IsShuffle;
                        row["RepeatType"] = user.RepeatType.ToString();
                        row["FavorateList"] = Util.Util.MakeMusicListStringFromList(user.FavorateList);
                        row["LastPlayMusic"] = user.LastPlayMusic;
                        row["PlayList"] = Util.Util.MakeMusicListStringFromList(user.PlayList);
                    }

                    UpdateUserInfo();

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("SaveUserData Exception = " + e.Message);
            }
        }

        public Music.MusicList RequestMusicList()
        {
            Music.MusicList music = new Music.MusicList();

            try {
                // musicList에 대해 데이터를 비우고 난 뒤에.
                musicList.MusicStorage.Clear();

                // 해당 테이블에 대해 데이터를 얻어낸다.
                DataTable table = DbDataSet.Tables["MusicList"];
                DataRowCollection rows = table.Rows;

                foreach (DataRow row in rows)
                {
                    // 해당 데이터 값을 새로 생성한다.
                    var m = new Music.Music(int.Parse(row["ID"].ToString()), row["MusicName"].ToString(), row["Artist"].ToString(), row["Album"].ToString(), row["DownloadURI"].ToString());
                    music.Add(m);
                    musicList.Add(m);
                    // 컨테이너에 삽입한다.
                }

                Debug.WriteLine("request music");

                foreach (var m in music.MusicStorage)
                {
                    Debug.WriteLine("Name = " + m.MusicName + " Uri = " + m.DownloadURI);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("RequestMusicList = " + e.Message);
            }

            return music;
        }
    }
}
