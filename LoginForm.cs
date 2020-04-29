using System;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class LoginForm : Form
    {
        public User.User UserSession { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
            // for test
        //    txtBox_Username.Text = "story";
        //    txtBox_Password.Text = "123123";
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txtBox_Username.Text == "")
            {
                MessageBox.Show("아이디를 입력하세요.");
                return;
            }

            if (txtBox_Password.Text == "")
            {
                MessageBox.Show("비밀번호를 입력하세요.");
                return;
            }

            // DataBase의 LoginRequest를 호출하여 정상적이 Session을 얻어내면 로그인을 하고 폼을 닫는다.
            UserSession = Database.Database.Instance.LoginRequest(txtBox_Username.Text, txtBox_Password.Text);
            if (UserSession != null)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("해당 아이디가 존재하지 않습니다.");
            }
        }

        private void btn_Signin_Click(object sender, EventArgs e)
        {
            var form = new SignInForm();
            form.ShowDialog();
        }
    }
}
