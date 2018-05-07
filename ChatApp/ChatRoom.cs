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
    public partial class ChatRoom : Form
    {
        private User info;

        public ChatRoom(User info)
        {
            InitializeComponent();
            this.info = info;
        }
    }
}
