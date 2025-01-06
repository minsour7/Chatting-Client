using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Sockets;

namespace ChatClient
{
    // 클라이언트의 텍스트 박스에 글을 쓰기위한 델리게이트
    // 실제 글을 쓰는것은 Form1클래스의 쓰레드가 아닌 다른 쓰레드인 ChatHandler의 스레드 이기에
    // ChatHandler의 쓰레드에서 이 델리게이트를 호출하여 서버에서 넘어오는 메세지를 쓴다
    delegate void SetTextDelegate(string s);

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

        // 다른 스레드인 ChatHandler의 쓰레드에서 호출하는 함수로 델리게이트를 통해 채팅 문자열을 텍스트 박스에 쓴다.
        public void SetText(string text)
        {
            if (this.txtChatMsg.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtChatMsg.AppendText(text);
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
            this.txtChatMsg = txtChatMsg;
            this.netStream = netStream;
            this.form1 = form1;
            this.strReader = new StreamReader(netStream);
        }

        public void ChatCloese()
        {
            netStream.Close();
            strReader.Close();
        }

        public void ChatProcess()
        {
            while (true)
            {
                try
                {
                    // 문자열 받음
                    string IstMessage = strReader.ReadLine();

                    if (IstMessage != null && IstMessage != "")
                    {
                        // SetText 메서드에서 델리게이트를 이용하여 서버에서 넘어오는 메세지를 쓴다.
                        form1.SetText(IstMessage + "\r\n");
                    }
                }
                catch (System.Exception Ex)
                {
                    break;
                }
            }
        }
    }
}
