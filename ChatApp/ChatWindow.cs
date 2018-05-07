using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ChatApp
{
    public partial class ChatRoom : Form
    {

        private Info user;
        IPEndPoint ipep; 
        Socket client;
        String userName;

        public ChatRoom(Info user)
        {
            // Tắt việc chặn sử dụng chéo tài nguyên giữa các luồng
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000); // Khai bao 1 dia chi IP va cong
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(ipep);
            }
            catch
            {
                MessageBox.Show("Server not found");
            }

            // Gửi thông tin user name về Server
            userName = user.name;
            datasend = Encoding.ASCII.GetBytes(userName);

            client.Send(datasend, datasend.Length, SocketFlags.None);

            // Tạo luồng Listen chạy song song với luồng main
            // Luôn luôn lắng nghe các gói tin từ server gửi về
            Thread listen = new Thread(ReceiveMessage);
            listen.IsBackground = true;
            listen.Start();
            
        }
        

        private void SendMessage(String message)
        {
            byte[] byteSend = new byte[1024];

            byteSend = Encoding.ASCII.GetBytes(userName + ": " + message);

            client.Send(byteSend, byteSend.Length, SocketFlags.None);

            typeArea.Clear();
        }

        private void ReceiveMessage()
        {
            try
            {
                Socket client2;

                
                while (true)
                {
                    byte[] datarecv = new byte[1024];
                    int recv = client.Receive(datarecv);
                    String message = Encoding.ASCII.GetString(datarecv, 0, recv);

                    //if (message[0] == '&' && message[1] == '&')
                    //Notification(message);
                    //else
                    //PrintMessage(message);
                    //chatHistory.Paste(message);
                    chatHistory.AppendText(message);
                    chatHistory.AppendText(Environment.NewLine);
                    //chatHistory.F
                }
            }
            catch
            {
                client.Close();
            }
        }

        
        static byte[] datasend;

        private void btSend_Click(object sender, EventArgs e)
        {
            String message;

            message = typeArea.Text;

            if (message != "")
                SendMessage(message);
            else
                MessageBox.Show("Blank message!");
        }

    }
}
