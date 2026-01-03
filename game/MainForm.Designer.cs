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
            SuspendLayout();
            // 
            // newGameBtn
            // 
            newGameBtn.Location = new Point(83, 342);
            newGameBtn.Name = "newGameBtn";
            newGameBtn.Size = new Size(112, 34);
            newGameBtn.TabIndex = 0;
            newGameBtn.Text = "New Game";
            newGameBtn.UseVisualStyleBackColor = true;
            newGameBtn.Click += newGameBtn_Click;
            // 
            // continueButton
            // 
            continueButton.Location = new Point(264, 342);
            continueButton.Name = "continueButton";
            continueButton.Size = new Size(112, 34);
            continueButton.TabIndex = 1;
            continueButton.Text = "Continue";
            continueButton.UseVisualStyleBackColor = true;
            continueButton.Click += continueButton_Click;
            // 
            // exitBtn
            // 
            exitBtn.Location = new Point(444, 342);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(112, 34);
            exitBtn.TabIndex = 2;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exitBtn);
            Controls.Add(continueButton);
            Controls.Add(newGameBtn);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button newGameBtn;
        private Button continueButton;
        private Button exitBtn;
    }
}