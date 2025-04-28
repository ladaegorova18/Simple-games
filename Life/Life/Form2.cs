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

        private void Form2Paint(object sender, PaintEventArgs e)
        {
            var leftBorder = pictureBox1.Width / 2 - game.Size * width / 2;
            var solidBrush = new SolidBrush(Color.OliveDrab);
            var whiteBrush = new SolidBrush(Color.Ivory);
            for (var i = 0; i < game.Size; ++i) // ага, и здесь можно лучше
            {
                for (var j = 0; j < game.Size; ++j)
                {
                    if (game.FindStableCells()[i, j] == 1)
                    {
                        e.Graphics.FillEllipse(solidBrush, i * width + leftBorder, j * height, width, height);
                        pictureBox1.Image = bmp;
                    }
                    else if (game.FindStableCells()[i, j] == -1)
                    {
                        e.Graphics.FillEllipse(whiteBrush, i * width + leftBorder, j * height, width, height);
                    }
                }
                pictureBox1.Image = bmp; // а он не создается много раз?
            }
        }
    }
}
