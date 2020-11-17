using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OursMarble
{
    public partial class ConnectServer : Form
    {
        public ConnectServer()
        {
            InitializeComponent();
        }

        private void ConnectServer_Load(object sender, EventArgs e)
        {

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (textBox_IPAddress.TextLength == 0)
            {
                MessageBox.Show("주소를 입력하세요.");
                return;
            }

            if (textBox_Port.TextLength == 0)
            {
                MessageBox.Show("포트를 입력하세요.");
                return;
            }

            if (textBox_UserID.TextLength == 0)
            {
                MessageBox.Show("이름을 입력하세요.");
                return;
            }

            //Form1으로 데이터 전달
            Form1 frm1 = new Form1(textBox_IPAddress.Text, Int32.Parse(textBox_Port.Text), textBox_UserID.Text);

            this.Visible = false;//ConnectServer 폼 닫기
            frm1.Show();//Form1 폼 열기
        }
    }
}
