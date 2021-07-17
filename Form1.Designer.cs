namespace TemTunesPlayer
{
    partial class temTunesPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(temTunesPlayer));
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonLoop = new System.Windows.Forms.Button();
            this.labelScoreID = new System.Windows.Forms.Label();
            this.scoreIdTextBox = new System.Windows.Forms.TextBox();
            this.buttonDownloadScore = new System.Windows.Forms.Button();
            this.labelScoreName = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelBy = new System.Windows.Forms.Label();
            this.labelBPM = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelLooping = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPlay.BackgroundImage")));
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPlay.Location = new System.Drawing.Point(12, 193);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(50, 50);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonStop.BackgroundImage")));
            this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStop.Location = new System.Drawing.Point(68, 193);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(50, 50);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonLoop
            // 
            this.buttonLoop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLoop.BackgroundImage")));
            this.buttonLoop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLoop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLoop.Location = new System.Drawing.Point(124, 193);
            this.buttonLoop.Name = "buttonLoop";
            this.buttonLoop.Size = new System.Drawing.Size(50, 50);
            this.buttonLoop.TabIndex = 2;
            this.buttonLoop.UseVisualStyleBackColor = true;
            this.buttonLoop.Click += new System.EventHandler(this.buttonLoop_Click);
            // 
            // labelScoreID
            // 
            this.labelScoreID.AutoSize = true;
            this.labelScoreID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelScoreID.ForeColor = System.Drawing.Color.White;
            this.labelScoreID.Location = new System.Drawing.Point(12, 12);
            this.labelScoreID.Name = "labelScoreID";
            this.labelScoreID.Size = new System.Drawing.Size(112, 29);
            this.labelScoreID.TabIndex = 3;
            this.labelScoreID.Text = "Score ID:";
            // 
            // scoreIdTextBox
            // 
            this.scoreIdTextBox.Location = new System.Drawing.Point(124, 15);
            this.scoreIdTextBox.Name = "scoreIdTextBox";
            this.scoreIdTextBox.Size = new System.Drawing.Size(268, 26);
            this.scoreIdTextBox.TabIndex = 4;
            // 
            // buttonDownloadScore
            // 
            this.buttonDownloadScore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDownloadScore.BackgroundImage")));
            this.buttonDownloadScore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDownloadScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDownloadScore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDownloadScore.Location = new System.Drawing.Point(398, 4);
            this.buttonDownloadScore.Name = "buttonDownloadScore";
            this.buttonDownloadScore.Size = new System.Drawing.Size(50, 50);
            this.buttonDownloadScore.TabIndex = 5;
            this.buttonDownloadScore.UseVisualStyleBackColor = true;
            this.buttonDownloadScore.Click += new System.EventHandler(this.buttonDownloadScore_Click);
            // 
            // labelScoreName
            // 
            this.labelScoreName.AutoSize = true;
            this.labelScoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelScoreName.ForeColor = System.Drawing.Color.White;
            this.labelScoreName.Location = new System.Drawing.Point(10, 75);
            this.labelScoreName.Name = "labelScoreName";
            this.labelScoreName.Size = new System.Drawing.Size(62, 32);
            this.labelScoreName.TabIndex = 6;
            this.labelScoreName.Text = "N/A";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.ForeColor = System.Drawing.Color.White;
            this.labelAuthor.Location = new System.Drawing.Point(37, 117);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(35, 20);
            this.labelAuthor.TabIndex = 7;
            this.labelAuthor.Text = "N/A";
            // 
            // labelBy
            // 
            this.labelBy.AutoSize = true;
            this.labelBy.ForeColor = System.Drawing.Color.White;
            this.labelBy.Location = new System.Drawing.Point(12, 117);
            this.labelBy.Name = "labelBy";
            this.labelBy.Size = new System.Drawing.Size(25, 20);
            this.labelBy.TabIndex = 8;
            this.labelBy.Text = "by";
            // 
            // labelBPM
            // 
            this.labelBPM.AutoSize = true;
            this.labelBPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelBPM.ForeColor = System.Drawing.Color.White;
            this.labelBPM.Location = new System.Drawing.Point(12, 147);
            this.labelBPM.Name = "labelBPM";
            this.labelBPM.Size = new System.Drawing.Size(111, 29);
            this.labelBPM.TabIndex = 9;
            this.labelBPM.Text = "N/A BPM";
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(180, 198);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(160, 32);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "App started";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelLooping
            // 
            this.labelLooping.AutoSize = true;
            this.labelLooping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelLooping.ForeColor = System.Drawing.Color.Red;
            this.labelLooping.Location = new System.Drawing.Point(181, 147);
            this.labelLooping.Name = "labelLooping";
            this.labelLooping.Size = new System.Drawing.Size(156, 29);
            this.labelLooping.TabIndex = 11;
            this.labelLooping.Text = "Looping OFF";
            // 
            // temTunesPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(455, 258);
            this.Controls.Add(this.labelLooping);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelBPM);
            this.Controls.Add(this.labelBy);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelScoreName);
            this.Controls.Add(this.buttonDownloadScore);
            this.Controls.Add(this.scoreIdTextBox);
            this.Controls.Add(this.labelScoreID);
            this.Controls.Add(this.buttonLoop);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "temTunesPlayer";
            this.Text = "TemTunes Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonLoop;
        private System.Windows.Forms.Label labelScoreID;
        private System.Windows.Forms.TextBox scoreIdTextBox;
        private System.Windows.Forms.Button buttonDownloadScore;
        private System.Windows.Forms.Label labelScoreName;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelBy;
        private System.Windows.Forms.Label labelBPM;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelLooping;
    }
}

