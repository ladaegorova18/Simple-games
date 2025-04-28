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
        private Bitmap bmp1;
        private Bitmap bmp2;
        private Graphics g1;
        private Graphics g2;
        private int width = 12;
        private int height = 10;
        private Pen pen;
        private Color oldColor;
        private PictureBox pictureBox1;
        private Stopwatch stopwatch = new Stopwatch();

        public Form1()
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Width = 800;
            pictureBox1.Height = 580 - 30;
            bmp1 = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            pictureBox2 = new PictureBox();
            pictureBox2.Width = 800;
            pictureBox2.Height = 580 - 30;
            bmp2 = new Bitmap(pictureBox2.Height, pictureBox2.Width);
            pen = new Pen(Color.Black);
            g1 = Graphics.FromImage(bmp1);
            g2 = Graphics.FromImage(bmp2);
            game = new Game();
            InitializeComponent();
        } // что-то с лейаутами, считать время

        private void StartClick(object sender, EventArgs e)
        {
            // спросить бы пользователя, какой размер поля ему нужен
            game.Limit = int.Parse(cellsCountText.Text);
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
            var leftBorder = pictureBox1.Width / 2 - game.Size * width / 2 - 50;
            var terraria = game.Terraria;
            PaintField(Color.Green, terraria, leftBorder, e);
            stepsCount.Text = game.Steps.ToString();
            WriteTime();
            cellsCountText.Text = game.CountCells().ToString();
        }

        private void PictureBox2Paint(object sender, PaintEventArgs e)
        {
            var terraria = game.FindStableCells();
            PaintField(Color.Brown, terraria, 0, e);
        }

        private void PaintField(Color color, int[,] terraria, int leftBorder, PaintEventArgs e)
        {
            var solidBrush = new SolidBrush(color);
            DrawCells(e, leftBorder, solidBrush, terraria);
            if (gridCheckBox.Checked)
            {
                DrawGrid(leftBorder, leftBorder + game.Size * width, height * game.Size, e);
            }
        }

        private void WriteTime()
        {
            var currentTime = stopwatch.Elapsed.ToString();
            time.Text = (currentTime).Substring(0, currentTime.Length - 6);
        }

        private void DrawCells(PaintEventArgs e, int leftBorder, SolidBrush solidBrush, int[,] terraria)
        {
            for (var i = 0; i < game.Size; ++i)
            {
                for (var j = 0; j < game.Size; ++j)
                {
                    if (game.ExistsBacteria(i, j, terraria))
                    {
                        e.Graphics.FillEllipse(solidBrush, i * width + leftBorder, j * height, width, height);
                    }
                }
            }
            pictureBox1.Image = bmp1;
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

        private void OnRestartClick(object sender, EventArgs e)
        {
            stopwatch.Restart();
            game = new Game();
            timer.Enabled = true;
        }

        private void OnStartMouseEnter(object sender, EventArgs e) => OnMouseEnter(start);

        private void OnStartMouseLeave(object sender, EventArgs e) => OnMouseLeave(start);

        private void OnStopButtonMouseEnter(object sender, EventArgs e) => OnMouseEnter(stop);

        private void OnStopButtonMouseLeave(object sender, EventArgs e) => OnMouseLeave(stop);

        private void OnExitButtonMouseEnter(object sender, EventArgs e) => OnMouseEnter(restart);

        private void OnExitMouseLeave(object sender, EventArgs e) => OnMouseLeave(restart);

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

