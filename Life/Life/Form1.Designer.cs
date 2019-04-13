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
            this.exit = new System.Windows.Forms.Button();
            this.stepText = new System.Windows.Forms.Label();
            this.stepsCount = new System.Windows.Forms.Label();
            this.timeText = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.cellsText = new System.Windows.Forms.Label();
            this.cellsCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.SeaGreen;
            this.start.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start.ForeColor = System.Drawing.Color.Cornsilk;
            this.start.Location = new System.Drawing.Point(384, 501);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(84, 36);
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
            this.stop.Location = new System.Drawing.Point(207, 501);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(85, 36);
            this.stop.TabIndex = 1;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Click += new System.EventHandler(this.OnStopClick);
            this.stop.MouseEnter += new System.EventHandler(this.OnStopButtonMouseEnter);
            this.stop.MouseLeave += new System.EventHandler(this.OnStopButtonMouseLeave);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.SeaGreen;
            this.exit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.Color.Cornsilk;
            this.exit.Location = new System.Drawing.Point(563, 501);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 36);
            this.exit.TabIndex = 2;
            this.exit.Text = "exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.OnExitClick);
            this.exit.MouseEnter += new System.EventHandler(this.OnExitButtonMouseEnter);
            this.exit.MouseLeave += new System.EventHandler(this.OnExitMouseLeave);
            // 
            // stepText
            // 
            this.stepText.AutoSize = true;
            this.stepText.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepText.Location = new System.Drawing.Point(27, 507);
            this.stepText.Name = "stepText";
            this.stepText.Size = new System.Drawing.Size(48, 21);
            this.stepText.TabIndex = 3;
            this.stepText.Text = "Step:";
            // 
            // stepsCount
            // 
            this.stepsCount.AutoSize = true;
            this.stepsCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepsCount.Location = new System.Drawing.Point(93, 507);
            this.stepsCount.Name = "stepsCount";
            this.stepsCount.Size = new System.Drawing.Size(19, 21);
            this.stepsCount.TabIndex = 4;
            this.stepsCount.Text = "0";
            // 
            // timeText
            // 
            this.timeText.AutoSize = true;
            this.timeText.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeText.Location = new System.Drawing.Point(24, 486);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(51, 21);
            this.timeText.TabIndex = 6;
            this.timeText.Text = "Time:";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time.Location = new System.Drawing.Point(93, 486);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(19, 21);
            this.time.TabIndex = 7;
            this.time.Text = "0";
            // 
            // cellsText
            // 
            this.cellsText.AutoSize = true;
            this.cellsText.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cellsText.Location = new System.Drawing.Point(26, 465);
            this.cellsText.Name = "cellsText";
            this.cellsText.Size = new System.Drawing.Size(49, 21);
            this.cellsText.TabIndex = 8;
            this.cellsText.Text = "Cells:";
            // 
            // cellsCount
            // 
            this.cellsCount.AutoSize = true;
            this.cellsCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cellsCount.Location = new System.Drawing.Point(93, 465);
            this.cellsCount.Name = "cellsCount";
            this.cellsCount.Size = new System.Drawing.Size(19, 21);
            this.cellsCount.TabIndex = 9;
            this.cellsCount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(800, 544);
            this.Controls.Add(this.cellsCount);
            this.Controls.Add(this.cellsText);
            this.Controls.Add(this.time);
            this.Controls.Add(this.timeText);
            this.Controls.Add(this.stepsCount);
            this.Controls.Add(this.stepText);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 580);
            this.Name = "Form1";
            this.Text = "Life";
            this.Load += new System.EventHandler(this.Form1Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label stepText;
        private System.Windows.Forms.Label stepsCount;
        private System.Windows.Forms.Label timeText;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label cellsText;
        private System.Windows.Forms.Label cellsCount;
    }
}

