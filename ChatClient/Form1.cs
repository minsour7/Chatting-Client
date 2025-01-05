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

        // ������ ä���� ����
        ChatHandler chatHandler = new ChatHandler();

        // ���� ��ư Ŭ��
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "����")
            {
                try
                {
                    tcpClient = new TcpClient();
                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 2025);
                    ntwStream = tcpClient.GetStream();

                    chatHandler.Setup(this, ntwStream, this.txtChatMsg);
                    Thread chatThread = new Thread(new ThreadStart(chatHandler.ChatProcess));
                    chatThread.Start();

                    //Message_Send("<" + txtName.Text + "> �Բ��� ���� �Ͽ����ϴ�", true);
                    btnConnect.Text = "������";
                }
                catch (System.Exception Ex)
                {
                    MessageBox.Show("Chatting Server ���� \n\n ���� :" + Ex.Message);
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
