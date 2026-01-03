namespace game
{
    partial class LevelCompleteForm
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
            label1 = new Label();
            scoreLabel = new Label();
            mainBtn = new Button();
            nxtLevelBtn = new Button();
            exitBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.RoyalBlue;
            label1.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(221, 31);
            label1.Name = "label1";
            label1.Size = new Size(349, 44);
            label1.TabIndex = 0;
            label1.Text = "LEVEL COMPLETED";
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.BackColor = Color.Black;
            scoreLabel.Font = new Font("Stencil", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            scoreLabel.ForeColor = SystemColors.ButtonFace;
            scoreLabel.Location = new Point(234, 181);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(134, 43);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "SCORE";
            // 
            // mainBtn
            // 
            mainBtn.BackColor = Color.Orange;
            mainBtn.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainBtn.Location = new Point(93, 328);
            mainBtn.Name = "mainBtn";
            mainBtn.Size = new Size(175, 60);
            mainBtn.TabIndex = 2;
            mainBtn.Text = "Main Menu";
            mainBtn.UseVisualStyleBackColor = false;
            mainBtn.Click += mainBtn_Click;
            // 
            // nxtLevelBtn
            // 
            nxtLevelBtn.BackColor = Color.OliveDrab;
            nxtLevelBtn.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nxtLevelBtn.Location = new Point(314, 330);
            nxtLevelBtn.Name = "nxtLevelBtn";
            nxtLevelBtn.Size = new Size(195, 58);
            nxtLevelBtn.TabIndex = 3;
            nxtLevelBtn.Text = "Next Level";
            nxtLevelBtn.UseVisualStyleBackColor = false;
            nxtLevelBtn.Click += nxtLevelBtn_Click;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.Red;
            exitBtn.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitBtn.Location = new Point(550, 330);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(141, 58);
            exitBtn.TabIndex = 4;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // LevelCompleteForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.image1;
            ClientSize = new Size(800, 450);
            Controls.Add(exitBtn);
            Controls.Add(nxtLevelBtn);
            Controls.Add(mainBtn);
            Controls.Add(scoreLabel);
            Controls.Add(label1);
            Name = "LevelCompleteForm";
            Text = "LevelCompleteForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label scoreLabel;
        private Button mainBtn;
        private Button nxtLevelBtn;
        private Button exitBtn;
    }
}