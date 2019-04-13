using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
        private Stopwatch stopwatch = new Stopwatch();

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
            var form2 = new Form2(game);
            form2.Show();
        } // что-то с лейаутами, считать время

        private void StartClick(object sender, EventArgs e)
        {
            timer.Enabled = true;
            stopwatch.Start();
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            game.Step();
            Refresh();
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

        private void Form1Paint(object sender, PaintEventArgs e)
        {
            var leftBorder = pictureBox1.Width / 2 - game.Size * width / 2;
            var solidBrush = new SolidBrush(Color.OliveDrab);
            DrawCells(e, leftBorder, solidBrush);
            DrawGrid(leftBorder, leftBorder + game.Size * width, height * game.Size, e);
            stepsCount.Text = game.Steps.ToString();
            WriteTime();
            cellsCount.Text = game.CountCells().ToString();
        }

        private void WriteTime()
        {
            var currentTime = stopwatch.Elapsed.ToString();
            time.Text = (currentTime).Substring(0, currentTime.Length - 6);
        }

        private void DrawCells(PaintEventArgs e, int leftBorder, SolidBrush solidBrush)
        {
            for (var i = 0; i < game.Size; ++i) // ага, и здесь можно лучше
            {
                for (var j = 0; j < game.Size; ++j)
                {
                    if (game.ExistsBacteria(i, j))
                    {
                        e.Graphics.FillEllipse(solidBrush, i * width + leftBorder, j * height, width, height);
                        pictureBox1.Image = bmp;
                    }
                }
            }
        }

        private void Form1Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void OnStopClick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            stopwatch.Stop();
        }

        private void OnExitClick(object sender, EventArgs e) => Close();

        private void OnStartMouseEnter(object sender, EventArgs e) => OnMouseEnter(start);

        private void OnStartMouseLeave(object sender, EventArgs e) => OnMouseLeave(start);

        private void OnStopButtonMouseEnter(object sender, EventArgs e) => OnMouseEnter(stop);

        private void OnStopButtonMouseLeave(object sender, EventArgs e) => OnMouseLeave(stop);

        private void OnExitButtonMouseEnter(object sender, EventArgs e) => OnMouseEnter(exit);

        private void OnExitMouseLeave(object sender, EventArgs e) => OnMouseLeave(exit);

        private void OnMouseEnter(Button button)
        {
            oldColor = button.BackColor;
            button.BackColor = Color.LimeGreen;
        }

        private void OnMouseLeave(Button button) => button.BackColor = oldColor;
    }
}

// при желании можно заменить сплошную раскраску бактерий на контур в методе DrawCells
// e.Graphics.DrawEllipse(pen, i * width + leftBorder, j * height, width, height); это эллипс как в условии, можно его

