using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Sockets;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient tcpClient = null;
        NetworkStream ntwStream = null;

        // 서버와 채팅을 실행
        ChatHandler chatHandler = new ChatHandler();

        // 입장 버튼 클릭
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "입장")
            {
                try
                {
                    tcpClient = new TcpClient();
                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 2025);
                    ntwStream = tcpClient.GetStream();

                    chatHandler.Setup(this, ntwStream, this.txtChatMsg);
                    Thread chatThread = new Thread(new ThreadStart(chatHandler.ChatProcess));
                    chatThread.Start();

                    //Message_Send("<" + txtName.Text + "> 님께서 접속 하였습니다", true);
                    btnConnect.Text = "나가기";
                }
                catch (System.Exception Ex)
                {
                    MessageBox.Show("Chatting Server 오류 \n\n 원인 :" + Ex.Message);
                }
            }
            else
            {

            }
        }
    }

    public class ChatHandler
    {
        private TextBox txtChatMsg;
        private NetworkStream netStream;
        private StreamReader strReader;
        private Form1 form1;

        public void Setup(Form1 form1, NetworkStream netStream, TextBox txtChatMsg)
        {

        }

        public void ChatProcess()
        {

        }
    }
}
