using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace OursMarble
{
    public partial class Form1 : Form
    {
        Board board;
        JsonElement map;
        int BOARD_TILE_COUNT = 8;
        TcpClient clientSocket = new TcpClient(); // 소켓
        NetworkStream stream = default(NetworkStream);

        int tileW;
        int tileH;

        int index = 0;
        int account = 10000000;
        string nickname = "";

        bool Dice_Flag = true;
        bool Ready_Flag = true;
        bool Game_Started = false;
        bool Is_My_Turn = false;
        bool Button_Disabled = false;

        public Form1(string _hostname, int _port, string _nickname)
        {
            InitializeComponent();

            try
            {
                clientSocket.Connect(_hostname, _port);
                stream = clientSocket.GetStream();
            }
            catch (Exception e)
            {
                MessageBox.Show("접속 실패");
                return;
            }

            nickname = _nickname;
        }

        private Point getBoardPoint(Point point)
        {
            return new Point(point.X * tileW, point.Y * tileH);
        }

        private void reset()
        {
            board = new Board();
            map = board.map;
            index = 0;
            account = 10000000;
            GameBoard.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            string openFilePath = System.Environment.CurrentDirectory;
            Graphics g = e.Graphics;
            GameBoard.Load(@"..\..\..\board.png");


        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (Dice_Flag)
            {
                dice1.Load(@"..\..\..\dice.gif");
                dice2.Load(@"..\..\..\dice.gif");
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Dice_Start.Text = "확정";
                Dice_Flag = false;

            }
            else
            {
                byte[] buffer = Encoding.Unicode.GetBytes("(SYSTEMCOMMAND),ROLL," + nickname + "," + account.ToString() + "," + index.ToString() + "$");
                stream.Write(buffer, 0, buffer.Length);

                stream.Flush();
                dice1.Image = null;
                dice2.Image = null;
                Dice_Flag = true;
                Dice_Start.Text = "주사위\n굴리기";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] buffer = Encoding.Unicode.GetBytes("leaveChat" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

            Application.ExitThread();
            Environment.Exit(0);
        }

        private void GetMessage() // 메세지 받기
        {
            while (true)
            {
                stream = clientSocket.GetStream();
                int BUFFERSIZE = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[BUFFERSIZE];
                int bytes = stream.Read(buffer, 0, buffer.Length);

                string messageRaw = Encoding.Unicode.GetString(buffer, 0, bytes);

                string[] messages = messageRaw.Split("$");

                foreach (var message in messages)
                {
                    string[] parsed = message.Split(",");

                    if (parsed[0].Equals("(SYSTEMCOMMAND)"))
                    {
                        switch (parsed[1])
                        {
                            case "ROLLR":
                                {
                                    DisplayText(parsed[2] + "님의 주사위 결과 " + (int.Parse(parsed[4]) - index) + "!!");
                                    index = int.Parse(parsed[4]) % 32;
                                    break;
                                }
                            case "READYR":
                                {
                                    DisplayText(parsed[2] + " : 준비완료!");
                                    break;
                                }
                            case "CANCELLR":
                                {
                                    DisplayText(parsed[2] + " : 취소!");
                                    break;
                                }
                            case "STARTR":
                                {
                                    Game_Started = true;
                                    reset();
                                    break;
                                }
                            case "MONEYADD":
                                {
                                    if (parsed[2] == nickname)
                                    {
                                        account += int.Parse(parsed[3]);
                                        label_account.Text = account.ToString();
                                    }
                                    break;
                                }
                            case "MONEYDEL":
                                {
                                    if (parsed[2] == nickname)
                                    {
                                        account -= int.Parse(parsed[3]);
                                        label_account.Text = account.ToString();
                                    }
                                    break;
                                }
                            case "TURNR":
                                {
                                    if (parsed[2] == nickname)
                                    {
                                        DisplayText(parsed[2] + "님 주사위를 굴려주세요!!!");
                                        Dice_Start.Enabled = true;
                                        Is_My_Turn = true;
                                    }
                                    else
                                    {
                                        Dice_Start.Enabled = false;
                                        Is_My_Turn = false;
                                    }
                                    Button_Disabled = true;
                                    //Ready_Button.Enabled = false;
                                    //Ready_Button.Hide();
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    else
                    {
                        DisplayText(message);
                    }

                }
            }
        }

        private void DisplayText(string text) // Server에 메세지 출력
        {
            if (log.InvokeRequired)
            {
                log.BeginInvoke(new MethodInvoker(delegate
                {
                    log.AppendText(text + Environment.NewLine);
                }));
            }
            else
                log.AppendText(text + Environment.NewLine);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Ready_Flag)
            {
                Ready_Button.Text = "준비\n취소";
                byte[] buffer = Encoding.Unicode.GetBytes("(SYSTEMCOMMAND),READY," + nickname + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                Ready_Flag = false;
            }
            else
            {
                Ready_Button.Text = "게임\n준비";
                byte[] buffer = Encoding.Unicode.GetBytes("(SYSTEMCOMMAND),CANCELL," + nickname + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                Ready_Flag = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(nickname + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

            reset();

            if (map.GetArrayLength() % 4 == 0)
            {
                BOARD_TILE_COUNT = map.GetArrayLength() / 4;
                tileW = GameBoard.Width / (BOARD_TILE_COUNT + 1);
                tileH = GameBoard.Height / (BOARD_TILE_COUNT + 1);
            }
            else
            {
                MessageBox.Show("맵 타일 개수가 4로 나누어지지 않습니다. 맵 파일을 다시 확인해주세요.");
            }

            Thread t_handler = new Thread(GetMessage);
            t_handler.IsBackground = true;
            t_handler.Start();
        }
    }
}
