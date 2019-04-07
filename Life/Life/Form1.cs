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
        private Game game;
        private Bitmap bmp;
        private Graphics g;
        private PictureBox pictureBox1;
        private int width = 12;
        private int height = 10;
        private Pen pen;
        private Color oldColor;

        public Form1()
        {
            game = new Game(); // спросить бы пользователя, какой размер поля ему нужен
            pictureBox1 = new PictureBox();
            pictureBox1.Width = 800;
            pictureBox1.Height = 580 - 30;
            bmp = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            pen = new Pen(Color.Black);
            g = Graphics.FromImage(bmp);
            InitializeComponent();
        } // что-то с лейаутами, считать время

        private void StartClick(object sender, EventArgs e) => timer.Enabled = true;

        private void Timer1Tick(object sender, EventArgs e)
        {
            game.Step();
            Refresh();
        }

        private void Form1Paint(object sender, PaintEventArgs e)
        {
            var leftBorder = pictureBox1.Width / 2 - game.Size * width / 2;
            var solidBrush = new SolidBrush(Color.OliveDrab);
            for (var i = 0; i < game.Size; ++i) // ага, и здесь можно лучше
            {
                for (var j = 0; j < game.Size; ++j)
                {
                    if (game.ExistsBacteria(i, j))
                    {
                        //e.Graphics.DrawEllipse(pen, i * width + leftBorder, j * height, width, height); это эллипс как в условии, можно его
                        e.Graphics.FillEllipse(solidBrush, i * width + leftBorder, j * height, width, height);
                        DrawBorders(leftBorder, e); // дорисовать границы
                        pictureBox1.Image = bmp;
                    }
                }
            }
            stepsCount.Text = game.Steps.ToString();         
        }

        private void DrawBorders(int leftBorder, PaintEventArgs e)
        {
            var point1 = new PointF(leftBorder, 0);
            var point2 = new PointF(leftBorder, game.Size * height);
            e.Graphics.DrawLine(pen, point1, point2);
            point1.X = leftBorder + game.Size * width;
            point2.X = point1.X;
            e.Graphics.DrawLine(pen, point1, point2);
        }

        private void Form1Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void OnStopClick(object sender, EventArgs e) => timer.Enabled = false;

        private void OnExitClick(object sender, EventArgs e) => Close();

        private void OnStartMouseEnter(object sender, EventArgs e)
        {
            oldColor = start.BackColor;
            start.BackColor = Color.LimeGreen;
        }

        private void OnStartMouseLeave(object sender, EventArgs e) => start.BackColor = oldColor;

        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            oldColor = exit.BackColor; // aaaaa copy-paste
            exit.BackColor = Color.LimeGreen;
        }

        private void OnExitMouseLeave(object sender, EventArgs e) => exit.BackColor = oldColor;

        private void OnStableCellsClick(object sender, EventArgs e)
        {
            var form2 = new Form2(game);
        }
    }
}
