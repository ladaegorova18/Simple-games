namespace Life
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.start = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.stop = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.stepText = new System.Windows.Forms.Label();
            this.stepsCount = new System.Windows.Forms.Label();
            this.timeText = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.cellsText = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gridCheckBox = new System.Windows.Forms.CheckBox();
            this.cellsCountText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.SeaGreen;
            this.start.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start.ForeColor = System.Drawing.Color.Cornsilk;
            this.start.Location = new System.Drawing.Point(541, 498);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(66, 34);
            this.start.TabIndex = 0;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.StartClick);
            this.start.MouseEnter += new System.EventHandler(this.OnStartMouseEnter);
            this.start.MouseLeave += new System.EventHandler(this.OnStartMouseLeave);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.Color.SeaGreen;
            this.stop.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stop.ForeColor = System.Drawing.Color.Cornsilk;
            this.stop.Location = new System.Drawing.Point(421, 498);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(67, 34);
            this.stop.TabIndex = 1;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Click += new System.EventHandler(this.OnStopClick);
            this.stop.MouseEnter += new System.EventHandler(this.OnStopButtonMouseEnter);
            this.stop.MouseLeave += new System.EventHandler(this.OnStopButtonMouseLeave);
            // 
            // restart
            // 
            this.restart.BackColor = System.Drawing.Color.SeaGreen;
            this.restart.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.restart.ForeColor = System.Drawing.Color.Cornsilk;
            this.restart.Location = new System.Drawing.Point(657, 498);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(57, 34);
            this.restart.TabIndex = 2;
            this.restart.Text = "restart";
            this.restart.UseVisualStyleBackColor = false;
            this.restart.Click += new System.EventHandler(this.OnRestartClick);
            this.restart.MouseEnter += new System.EventHandler(this.OnExitButtonMouseEnter);
            this.restart.MouseLeave += new System.EventHandler(this.OnExitMouseLeave);
            // 
            // stepText
            // 
            this.stepText.AutoSize = true;
            this.stepText.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepText.Location = new System.Drawing.Point(12, 99);
            this.stepText.Name = "stepText";
            this.stepText.Size = new System.Drawing.Size(40, 19);
            this.stepText.TabIndex = 3;
            this.stepText.Text = "Step:";
            // 
            // stepsCount
            // 
            this.stepsCount.AutoSize = true;
            this.stepsCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepsCount.Location = new System.Drawing.Point(66, 99);
            this.stepsCount.Name = "stepsCount";
            this.stepsCount.Size = new System.Drawing.Size(17, 19);
            this.stepsCount.TabIndex = 4;
            this.stepsCount.Text = "0";
            // 
            // timeText
            // 
            this.timeText.AutoSize = true;
            this.timeText.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeText.Location = new System.Drawing.Point(11, 124);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(41, 19);
            this.timeText.TabIndex = 6;
            this.timeText.Text = "Time:";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time.Location = new System.Drawing.Point(66, 124);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(17, 19);
            this.time.TabIndex = 7;
            this.time.Text = "0";
            // 
            // cellsText
            // 
            this.cellsText.AutoSize = true;
            this.cellsText.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cellsText.Location = new System.Drawing.Point(113, 505);
            this.cellsText.Name = "cellsText";
            this.cellsText.Size = new System.Drawing.Size(40, 19);
            this.cellsText.TabIndex = 8;
            this.cellsText.Text = "Cells:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(830, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(644, 500);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox2Paint);
            // 
            // gridCheckBox
            // 
            this.gridCheckBox.AutoSize = true;
            this.gridCheckBox.Checked = true;
            this.gridCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridCheckBox.Location = new System.Drawing.Point(1078, 512);
            this.gridCheckBox.Name = "gridCheckBox";
            this.gridCheckBox.Size = new System.Drawing.Size(69, 17);
            this.gridCheckBox.TabIndex = 11;
            this.gridCheckBox.Text = "draw grid";
            this.gridCheckBox.UseVisualStyleBackColor = true;
            // 
            // cellsCountText
            // 
            this.cellsCountText.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cellsCountText.Location = new System.Drawing.Point(180, 506);
            this.cellsCountText.Name = "cellsCountText";
            this.cellsCountText.Size = new System.Drawing.Size(100, 25);
            this.cellsCountText.TabIndex = 12;
            this.cellsCountText.Text = "600";
            this.cellsCountText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cellsCountText.Validating += new System.ComponentModel.CancelEventHandler(this.CellsCountTextValidating);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(1507, 544);
            this.Controls.Add(this.gridCheckBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cellsCountText);
            this.Controls.Add(this.cellsText);
            this.Controls.Add(this.time);
            this.Controls.Add(this.timeText);
            this.Controls.Add(this.stepsCount);
            this.Controls.Add(this.stepText);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 580);
            this.Name = "Form1";
            this.Text = "Life";
            this.Load += new System.EventHandler(this.Form1Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Label stepText;
        private System.Windows.Forms.Label stepsCount;
        private System.Windows.Forms.Label timeText;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label cellsText;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox gridCheckBox;
        private System.Windows.Forms.TextBox cellsCountText;
    }
}

