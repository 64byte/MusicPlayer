using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void btn_SignIn_Click(object sender, EventArgs e)
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

            if (txtBox_Email.Text == "")
            {
                MessageBox.Show("이메일을 입력하세요.");
                return;
            }

            if (Database.Database.Instance.IsRegsistedUser(txtBox_Username.Text))
            {
                MessageBox.Show("이미 존재하는 아이디 입니다.");
                return;
            }

            int index = Database.Database.Instance.GetLastIndex();
            if (Database.Database.Instance.RegisterUserData(new User.User(index+1, txtBox_Username.Text, txtBox_Password.Text)))
            {
                MessageBox.Show("아이디가 성공적으로 만들어졌습니다.");
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("데이터베이스 접속에 실패했습니다. 나중에 다시 시도해주세요.");
                return;
            }
        }
    }
}
