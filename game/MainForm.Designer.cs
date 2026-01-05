namespace game
{
    partial class MainForm
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
            newGameBtn = new Button();
            continueButton = new Button();
            exitBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // newGameBtn
            // 
            newGameBtn.BackColor = Color.FromArgb(0, 192, 192);
            newGameBtn.Font = new Font("Bernard MT Condensed", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newGameBtn.ForeColor = SystemColors.ActiveCaptionText;
            newGameBtn.Location = new Point(268, 202);
            newGameBtn.Margin = new Padding(5, 4, 5, 4);
            newGameBtn.Name = "newGameBtn";
            newGameBtn.Size = new Size(293, 66);
            newGameBtn.TabIndex = 0;
            newGameBtn.Text = "New Game";
            newGameBtn.UseVisualStyleBackColor = false;
            newGameBtn.Click += newGameBtn_Click;
            // 
            // continueButton
            // 
            continueButton.BackColor = Color.FromArgb(255, 192, 128);
            continueButton.Font = new Font("Bernard MT Condensed", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            continueButton.ForeColor = SystemColors.ActiveCaptionText;
            continueButton.Location = new Point(268, 304);
            continueButton.Margin = new Padding(5, 4, 5, 4);
            continueButton.Name = "continueButton";
            continueButton.Size = new Size(293, 60);
            continueButton.TabIndex = 1;
            continueButton.Text = "Continue";
            continueButton.UseVisualStyleBackColor = false;
            continueButton.Click += continueButton_Click;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.OrangeRed;
            exitBtn.Font = new Font("Bernard MT Condensed", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitBtn.ForeColor = SystemColors.ActiveCaptionText;
            exitBtn.Location = new Point(268, 398);
            exitBtn.Margin = new Padding(5, 4, 5, 4);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(293, 66);
            exitBtn.TabIndex = 2;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkSalmon;
            label1.Font = new Font("Bernard MT Condensed", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(175, 57);
            label1.Name = "label1";
            label1.Size = new Size(475, 85);
            label1.TabIndex = 3;
            label1.Text = "SPACE SHOOTER";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(18F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(867, 553);
            Controls.Add(label1);
            Controls.Add(exitBtn);
            Controls.Add(continueButton);
            Controls.Add(newGameBtn);
            Font = new Font("Algerian", 14F, FontStyle.Bold);
            Margin = new Padding(5, 4, 5, 4);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button newGameBtn;
        private Button continueButton;
        private Button exitBtn;
        private Label label1;
    }
}