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
    public partial class Form1 : Form
    {
        private GameLogic gameLogic;
        private Bitmap bmp;
        private Graphics g;
        private PictureBox pictureBox1;
        private int width = 12;
        private int height = 10;
        private Pen pen;
        public Form1()
        {
            gameLogic = new GameLogic(); // спросить бы пользователя, какой размер поля ему нужен
            pictureBox1 = new PictureBox();
            pictureBox1.Width = gameLogic.Limit * width;
            pictureBox1.Height = gameLogic.Limit * height;
            bmp = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            pen = new Pen(Color.Black);
            g = Graphics.FromImage(bmp);
            InitializeComponent();
        }

        private void StartClick(object sender, EventArgs e) => timer1.Enabled = true;

        private void Timer1Tick(object sender, EventArgs e)
        {
            gameLogic.Step();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (var i = 0; i < gameLogic.Size; ++i) // ага, и здесь можно лучше
            {
                for (var j = 0; j < gameLogic.Size; ++j)
                {
                    if (gameLogic.ExistsBacteria(i, j))
                    {
                        //g.DrawRectangle(pen, 100, 100, 200, 200);
                        e.Graphics.DrawEllipse(pen, i * width, j * height, width, height);
                        //e.Graphics.DrawLine(pen, new Point(0, 0), new Point(35, 35));
                        pictureBox1.Image = bmp;
                    }
                }
            }
        }
    }
}
