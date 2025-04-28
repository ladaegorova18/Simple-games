namespace TickTackToe
{
    partial class TickTackToe
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
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Start = new System.Windows.Forms.Button();
            this.modeText = new System.Windows.Forms.Label();
            this.singlePlayerButton = new System.Windows.Forms.Button();
            this.twoPlayersButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(27, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(360, 360);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(167, 392);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(88, 28);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.StartClick);
            // 
            // modeText
            // 
            this.modeText.AutoSize = true;
            this.modeText.Location = new System.Drawing.Point(194, 423);
            this.modeText.Name = "modeText";
            this.modeText.Size = new System.Drawing.Size(34, 13);
            this.modeText.TabIndex = 2;
            this.modeText.Text = "single";
            // 
            // singlePlayerButton
            // 
            this.singlePlayerButton.Location = new System.Drawing.Point(54, 392);
            this.singlePlayerButton.Name = "singlePlayerButton";
            this.singlePlayerButton.Size = new System.Drawing.Size(80, 28);
            this.singlePlayerButton.TabIndex = 3;
            this.singlePlayerButton.Text = "Single player";
            this.singlePlayerButton.UseVisualStyleBackColor = true;
            this.singlePlayerButton.Click += new System.EventHandler(this.SinglePlayerButtonClick);
            // 
            // twoPlayersButton
            // 
            this.twoPlayersButton.Location = new System.Drawing.Point(285, 392);
            this.twoPlayersButton.Name = "twoPlayersButton";
            this.twoPlayersButton.Size = new System.Drawing.Size(80, 28);
            this.twoPlayersButton.TabIndex = 4;
            this.twoPlayersButton.Text = "Multiplayer";
            this.twoPlayersButton.UseVisualStyleBackColor = true;
            this.twoPlayersButton.Click += new System.EventHandler(this.TwoPlayersButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "mode:";
            // 
            // TickTackToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.twoPlayersButton);
            this.Controls.Add(this.singlePlayerButton);
            this.Controls.Add(this.modeText);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.pictureBox);
            this.Name = "TickTackToe";
            this.Text = "TickTackToe";
            this.Load += new System.EventHandler(this.TickTackToeLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TickTackToePaint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label modeText;
        private System.Windows.Forms.Button singlePlayerButton;
        private System.Windows.Forms.Button twoPlayersButton;
        private System.Windows.Forms.Label label1;
    }
}

