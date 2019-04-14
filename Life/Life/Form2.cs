using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Life
{
    public partial class Form2 : Form
    {
        private Game game;
        //int Size { get; set; } = 50; // сделать бы его только get
        private Bitmap bmp;
        private Graphics g;
        private PictureBox pictureBox1;
        private int width = 12;
        private int height = 10;
        private Pen pen;

        public Form2(Game game)
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Width = 800;
            pictureBox1.Height = 580 - 30;
            bmp = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            pen = new Pen(Color.Black);
            g = Graphics.FromImage(bmp);
            InitializeComponent(); // хорошо ли для инкапсуляции?
            this.game = game;
        }

        private void Form2Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void DrawCells(PaintEventArgs e, int leftBorder, SolidBrush solidBrush)
        {
            var stableTerraria = game.FindStableCells();
            for (var i = 0; i < game.Size; ++i) // ага, и здесь можно лучше
            {
                for (var j = 0; j < game.Size; ++j)
                {
                    if (stableTerraria[i, j] == 1)
                    {
                        e.Graphics.FillEllipse(solidBrush, i * width + leftBorder, j * height, width, height);
                        pictureBox1.Image = bmp;
                    }
                }
            }
        }

        private void Form2Paint(object sender, PaintEventArgs e)
        {
            var leftBorder = pictureBox1.Width / 2 - game.Size * width / 2;
            var solidBrush = new SolidBrush(Color.OliveDrab);
            DrawCells(e, leftBorder, solidBrush);
            DrawGrid(leftBorder, leftBorder + game.Size * width, height * game.Size, e);
        }

        private void DrawGrid(int leftBorder, int rightBorder, int gameHeight, PaintEventArgs e)
        {
            for (var i = 0; i <= gameHeight; i += height)
            {
                var point1 = new PointF(leftBorder, i);
                var point2 = new PointF(rightBorder, i);
                e.Graphics.DrawLine(pen, point1, point2);
            }
            for (var j = leftBorder; j <= rightBorder; j += width)
            {
                var point1 = new PointF(j, 0);
                var point2 = new PointF(j, gameHeight);
                e.Graphics.DrawLine(pen, point1, point2);
            }
        }
    }
}
