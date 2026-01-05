namespace game
{
    partial class GameOver
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
            mainMenuBtn = new Button();
            exitBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.MenuHighlight;
            label1.Font = new Font("Showcard Gothic", 28F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(205, 73);
            label1.Name = "label1";
            label1.Size = new Size(338, 68);
            label1.TabIndex = 0;
            label1.Text = "GAME OVER\r\n";
            // 
            // mainMenuBtn
            // 
            mainMenuBtn.BackColor = SystemColors.Info;
            mainMenuBtn.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            mainMenuBtn.Location = new Point(70, 230);
            mainMenuBtn.Name = "mainMenuBtn";
            mainMenuBtn.Size = new Size(242, 55);
            mainMenuBtn.TabIndex = 1;
            mainMenuBtn.Text = "MAIN MENU";
            mainMenuBtn.UseVisualStyleBackColor = false;
            mainMenuBtn.Click += mainMenuBtn_Click;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = SystemColors.InactiveCaption;
            exitBtn.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            exitBtn.Location = new Point(456, 230);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(214, 55);
            exitBtn.TabIndex = 2;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // GameOver
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 450);
            Controls.Add(exitBtn);
            Controls.Add(mainMenuBtn);
            Controls.Add(label1);
            Name = "GameOver";
            Text = "GameOver";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button mainMenuBtn;
        private Button exitBtn;
    }
}