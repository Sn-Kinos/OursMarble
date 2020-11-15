using System.Diagnostics;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;

namespace OursMarble
{
    public partial class Form1 : Form
    {
        Board board;
        JsonElement map;
        int BOARD_TILE_COUNT = 8;

        int tileW;
        int tileH;

        public Form1()
        {
            InitializeComponent();
            board = new Board();
            map = board.map;

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

        }

        private Point getBoardPoint(Point point)
        {
            return new Point(point.X * tileW, point.Y * tileH);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Point[] vertex =
            {
                new Point(BOARD_TILE_COUNT, BOARD_TILE_COUNT),
                new Point(0, BOARD_TILE_COUNT),
                new Point(0, 0),
                new Point(BOARD_TILE_COUNT, 0),
            };

            Font font = new Font("Malgun Gothic", 10);
            Rectangle rectangle;
            Size size = new Size(tileW, tileH);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;


            for (int i = 0; i < map.GetArrayLength(); i++)
            {
                int index = i % BOARD_TILE_COUNT;
                if (index == 0)
                {
                    rectangle = new Rectangle(getBoardPoint(vertex[i / BOARD_TILE_COUNT]), size);
                    g.DrawString(map[i].GetProperty("name").ToString(), font, Brushes.Black, rectangle, stringFormat);
                }
                else
                {
                    Debug.WriteLine(map[i].GetProperty("name") + " " + index.ToString());
                    Point start = new Point();
                    Point end = new Point();
                    switch (i / BOARD_TILE_COUNT)
                    {
                        case 0:
                            {
                                // 7,8 ~ 1,8
                                start = new Point(BOARD_TILE_COUNT - index, BOARD_TILE_COUNT);
                                end = new Point(BOARD_TILE_COUNT - index, BOARD_TILE_COUNT + 1);
                                break;
                            }
                        case 1:
                            {
                                // 0,7 ~ 0,1
                                start = new Point(0, BOARD_TILE_COUNT - index);
                                end = new Point(1, BOARD_TILE_COUNT - index);
                                break;
                            }
                        case 2:
                            {
                                // 1,0 ~ 7,0
                                start = new Point(index, 0);
                                end = new Point(index, 1);
                                break;
                            }
                        case 3:
                            {
                                // 7,1 ~ 7,7
                                start = new Point(BOARD_TILE_COUNT, index);
                                end = new Point(BOARD_TILE_COUNT + 1, index);
                                break;
                            }
                        default:
                            break;
                    }

                    rectangle = new Rectangle(getBoardPoint(start), size);
                    if (map[i].GetProperty("type").ToString() == "land")
                    {
                        Brush brush;
                        board.colors.TryGetValue(map[i].GetProperty("color").ToString(), out brush);
                        g.FillRectangle(brush, rectangle);
                    }
                    g.DrawLine(Pens.Black, getBoardPoint(start), getBoardPoint(end));
                    g.DrawString(map[i].GetProperty("name").ToString(), font, Brushes.Black, rectangle, stringFormat);
                }
            }

            g.DrawLine(Pens.Black, 0, tileH, GameBoard.Width, tileH);
            g.DrawLine(Pens.Black, 0, GameBoard.Width - tileH, GameBoard.Width, GameBoard.Width - tileH);
            g.DrawLine(Pens.Black, tileW, 0, tileW, GameBoard.Height);
            g.DrawLine(Pens.Black, GameBoard.Height - tileW, 0, GameBoard.Height - tileW, GameBoard.Height);
        }
    }
}
