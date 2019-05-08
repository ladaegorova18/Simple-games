using System;
using System.Drawing;
using System.Windows.Forms;

namespace TickTackToe
{
    public partial class TickTackToe : Form
    {
        private Bitmap bmp1;
        private string mode = "single";
        private Game game;
        private Graphics g;
        //private PictureBox pictureBox;
        
        public TickTackToe()
        {
            pictureBox = new PictureBox();
            InitializeComponent();
        }

        private void TickTackToeLoad(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void DrawGrid(PaintEventArgs e)
        {
            bmp1 = new Bitmap(pictureBox.Height, pictureBox.Width);
            g = Graphics.FromImage(bmp1);
            var thirdSize = pictureBox.Width / 3;
            var left = pictureBox.Left;
            var top = pictureBox.Top;
            var pen = new Pen(Color.Black, 10);
            for (var i = 1; i < 3; ++i)
            {
                var point1 = new PointF(left + thirdSize * i, top);
                var point2 = new PointF(left + thirdSize * i, pictureBox.Height);
                g.DrawLine(pen, point1, point2);
            }
            for (var i = 1; i < 3; ++i)
            {
                var point1 = new PointF(left, top + thirdSize * i);
                var point2 = new PointF(left + pictureBox.Width, top + thirdSize * i);
                g.DrawLine(pen, point1, point2);
            }
            pictureBox.Image = bmp1;
        }

        private void TickTackToePaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e);
        }

        private void StartClick(object sender, EventArgs e)
        {
            game = new Game(mode);
            game.Start();
        }

        private void SinglePlayerButtonClick(object sender, EventArgs e)
        {
            mode = "single";
            modeText.Text = mode;
        }

        private void TwoPlayersButton_Click(object sender, EventArgs e)
        {
            mode = "multi";
            modeText.Text = mode;
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            var coords = MousePosition;
            coords = StandardCoords(coords);
            if (game.Free(coords.X, coords.Y))
            {
                game.Move(coords.X, coords.Y);
            }
        }

        private Point StandardCoords(Point coords)
        {
            coords.X = (int)Math.Floor((double)coords.X * 3 / pictureBox.Width);
            coords.Y = (int)Math.Floor((double)coords.Y * 3 / pictureBox.Width);
            return coords;
        }
    }
}
