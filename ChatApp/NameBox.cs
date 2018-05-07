using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    
    public partial class NameBox : Form
    {
        public NameBox()
        {   
            // Hiển thị hộp thoại để nhập tên User
            InitializeComponent();
        }

        // Xử lí sự kiện khi người dùng ấn Confirm
        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Username must have at least 1 character.");
            }
            else
            {
                Info obj = new Info();
                obj.name = textBox1.Text;
                
                // Kết quả tên user đc gửi qua Form tiếp theo
                ChatRoom f = new ChatRoom(obj);
                f.Show();

                this.Hide();
            }
        }

        private void NameBox_Load(object sender, EventArgs e)
        {

        }
    }

    public class Info
    {
        public string name { set; get; }
    }
}
